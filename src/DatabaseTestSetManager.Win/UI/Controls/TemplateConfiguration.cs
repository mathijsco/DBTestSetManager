using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Win.Properties;
using DatabaseTestSetManager.Lib.Razor;
using System.Dynamic;
using DatabaseTestSetManager.Lib.DataHandlers.DataValidators;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DatabaseTestSetManager.Win.UI.Controls.Modules.TextBoxModules;
using DatabaseTestSetManager.Lib.Razor.Models;
using System.Collections;
using DatabaseTestSetManager.Lib.ScriptBuilders.CustomActionModels;

namespace DatabaseTestSetManager.Win.UI.Controls
{
    public partial class TemplateConfiguration : UserControl
    {
        private TreeNode _parametersTreeNode;
        private IList<ColumnSpec> _columnsOfCurrentModel;
        private ColumnSpec _currentColumn;
        private IList<TypedVariable> _localVariables;

        public TemplateConfiguration()
        {
            InitializeComponent();

            imageListNodes.Images.Add("namespace", Resources.Namespace);
            imageListNodes.Images.Add("class", Resources.Class);
            imageListNodes.Images.Add("method", Resources.Method);
            imageListNodes.Images.Add("field", Resources.Field);

            txtTemplate.AddModule(new SelectAllTextModule());
            txtOutput.AddModule(new SelectAllTextModule());

            txtTemplate.Font = new Font(FontFamily.GenericMonospace, 8.5f);
            txtOutput.Font = new Font(FontFamily.GenericMonospace, 8.5f);
        }
        
        public TemplateSpec GenerateSpec()
        {
            return new TemplateSpec()
            {
                Template = txtTemplate.Text,
                DefaultVariables = _localVariables,
                TrimWhitespaces = chkTrimWhitespaces.Checked
            };
        }

        public void LoadSpec(TemplateSpec spec)
        {
            if (spec == null) return;

            txtTemplate.Text = spec.Template;
            chkTrimWhitespaces.Checked = spec.TrimWhitespaces;
            _localVariables = spec.DefaultVariables;
            //ReloadVariables();
        }
        
        public void LoadModel(IList<ColumnSpec> columnsOfCurrentModel = null, ColumnSpec currentColumn = null)
        {
            _columnsOfCurrentModel = columnsOfCurrentModel;
            _currentColumn = currentColumn;

            var myModel = CreateSampleModel();
            var root = new TreeNode("Model");

            BuildTreeHierarchy(root, myModel);

            // Get the parameters node
            _parametersTreeNode = root.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == "Parameters");

            // Add the root node to the tree
            treeModelExplorer.Nodes.Add(root);
            root.Expand();
        }

        private static TreeNode CreateNode(string name, string imageKey, string addition = null)
        {
            return new TreeNode(name) { ImageKey = imageKey, SelectedImageKey = imageKey, Tag = addition };
        }

        private void treeModelExplorer_DoubleClick(object sender, EventArgs e)
        {
            var selected = treeModelExplorer.SelectedNode;
            if (selected == null || string.IsNullOrEmpty(selected.ImageKey) || selected.ImageKey == "namespace" || selected.ImageKey == "class") return;

            var text = "@" + selected.FullPath + (selected.Tag as string ?? string.Empty);
            var currentPos = txtTemplate.SelectionStart;
            var prevChar = currentPos == 0 ? '\0' : txtTemplate.Text[currentPos - 1];
            if (Regex.IsMatch(prevChar.ToString(), @"\w"))
                text = "@(" + text + ")";

            txtTemplate.SelectedText = text;
        }

        private async void tabControls_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != tabOutput) return;

            txtOutput.Text = "Compiling...";
            var result = await CompileAndRun();
            txtOutput.Text = result;
        }

        private void tbtnWordWrap_Click(object sender, EventArgs e)
        {
            txtTemplate.WordWrap = !txtTemplate.WordWrap;
            txtOutput.WordWrap = txtTemplate.WordWrap;
            tbtnWordWrap.Checked = txtTemplate.WordWrap;
        }

        private void tbtnManageVariables_Click(object sender, EventArgs e)
        {
            var form = new RazorLocalParamsForm();
            form.LoadData(_localVariables);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _localVariables = form.CurrentVariables;
                ReloadVariables();
                _parametersTreeNode.Expand();
            }
        }

        private void ReloadVariables()
        {
            _parametersTreeNode.Nodes.Clear();
            if (_localVariables == null) return;

            foreach (var variable in _localVariables)
                _parametersTreeNode.Nodes.Add(CreateNode(variable.Key, "field"));
        }

        private async Task<string> CompileAndRun()
        {
            return await Task.Factory.StartNew(() =>
            {
                var engine = TemplateEngineFactory.ForColumn(_currentColumn?.Guid ?? Guid.Empty);

                var text = txtTemplate.Text;
                if (chkTrimWhitespaces.Checked)
                    text = Regex.Replace(text, @"(?:\r?\n)(?:\t| )*", " ", RegexOptions.Multiline);

                if (!engine.TryCompile(text))
                {
                    MessageBox.Show("There is a syntax error in the Razor template.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string output;
                if (!engine.TryExecute(CreateSampleModel(), out output))
                {
                    MessageBox.Show("There is a execution error in the Razor template.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                return output;
            });
        }

        private object CreateSampleModel()
        {
            var random = new Random();

            // Create the current model
            var model = new ExpandoObject() as IDictionary<string, object>;
            if (_columnsOfCurrentModel != null)
            {
                foreach (var spec in _columnsOfCurrentModel)
                {
                    // Skip my own column
                    if (_currentColumn != null && spec.Guid == _currentColumn.Guid)
                        continue;

                    model.Add(spec.Name, CreateSampleValue(random, spec.Type, spec.Name));
                }
            }

            // Create the whiteboard model
            var whiteboardModel = new ExpandoObject() as IDictionary<string, object>;
            ApplicationState.Instance.Whiteboard.ForEach(item => whiteboardModel.Add(item.Key, DataValidatorFactory.Create(item.Type).Parse(item.Value)));

            // Create the parameter model
            var parameterModel = new ExpandoObject() as IDictionary<string, object>;
            if (_localVariables != null)
            {
                foreach (var variable in _localVariables)
                    parameterModel.Add(variable.Key, DataValidatorFactory.Create(variable.Type).Parse(variable.Value) ?? CreateSampleValue(random, variable.Type, variable.Key));
            }
            
            return new DefaultTemplateModel
            {
                Current = model,
                Whiteboard = whiteboardModel,
                Parameters = parameterModel,
                Special = new SpecialTemplateModel
                {
                    TableName = "MyTableName",
                    RowNumber = 10,
                    TotalRows = 20
                },
                Actions = new DefaultActionModel()
            };
        }

        private object CreateSampleValue(Random random, FieldType fieldType, string name)
        {
            object value = null;
            switch (fieldType)
            {
                case FieldType.String:
                    value = "My" + name + "Value";
                    break;
                case FieldType.Number:
                    value = random.Next(1000) / 10d;
                    break;
                case FieldType.Guid:
                    value = Guid.NewGuid();
                    break;
                case FieldType.DataTimeOffset:
                    value = DateTimeOffset.Now;
                    break;
                case FieldType.TimeSpan:
                    value = TimeSpan.FromSeconds(random.Next(1000) / 10d);
                    break;
                case FieldType.Raw:
                    value = "Raw" + name + "Thingy('\"TestSetManager',1)";
                    break;
                default:
                    throw new NotSupportedException("The following column type is not supported: " + fieldType);
            }
            return value;
        }

        private void BuildTreeHierarchy(TreeNode parent, object model)
        {
            var modelType = model.GetType();

            var modelAsDictionary = model as IEnumerable<KeyValuePair<string, object>>;
            if (modelAsDictionary != null)
            {
                foreach (var item in modelAsDictionary)
                    parent.Nodes.Add(CreateNode(item.Key, "field"));
                return;
            }

            // Process the rest
            foreach (var propery in modelType.GetProperties())
            {
                var propertyValue = propery.GetValue(model);
                var propertyType = propertyValue.GetType();

                var modelAsDelegate = propertyValue as Delegate;
                if (modelAsDelegate != null)
                {
                    var args = modelAsDelegate.Method.GetParameters().Select(p => p.ParameterType.Name + ": " + p.Name).Aggregate((s1, s2) => s1 + ", " + s2);
                    parent.Nodes.Add(CreateNode(propery.Name, "method", "(" + args + ")"));
                    continue;
                }

                if (propertyType.IsPrimitive || propertyValue is string)
                {
                    parent.Nodes.Add(CreateNode(propery.Name, "field"));
                    continue;
                }

                // Other classes
                if (propertyType.IsClass)
                {
                    var node = CreateNode(propery.Name, "class");
                    BuildTreeHierarchy(node, propertyValue);
                    parent.Nodes.Add(node);
                }
            }

            // Add the custom methods
            foreach (var method in modelType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (method.IsSpecialName || method.DeclaringType != modelType) continue;
                var args = method.GetParameters().Select(p => p.Name + ": " + p.ParameterType.Name).DefaultIfEmpty(string.Empty).Aggregate((s1, s2) => s1 + ", " + s2);
                parent.Nodes.Add(CreateNode(method.Name, "method", "(" + args + ")"));
            }
        }

    }
}
