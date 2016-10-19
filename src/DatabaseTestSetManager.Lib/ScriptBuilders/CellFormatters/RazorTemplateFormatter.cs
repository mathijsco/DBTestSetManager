using DatabaseTestSetManager.Lib.Models.Generation;
using System.Collections.Generic;
using System.Linq;
using DatabaseTestSetManager.Lib.Razor;
using System.Dynamic;
using System.Diagnostics;
using DatabaseTestSetManager.Lib.DataHandlers.DataValidators;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Lib.Helpers;
using DatabaseTestSetManager.Lib.Razor.Models;
using System.Text.RegularExpressions;
using System;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CellFormatters
{
    public class RazorTemplateFormatter : ICellFormatter
    {
        private readonly IActionTemplateModel _actionTemplateModel;

        public RazorTemplateFormatter(IActionTemplateModel actionTemplateModel)
        {
            if (actionTemplateModel == null) throw new ArgumentNullException("actionTemplateModel");

            _actionTemplateModel = actionTemplateModel;
        }

        public ResolvedValue FormatCell(CellContext context)
        {
            // Compile and get the value
            // If current has a non-ResolvedValue, hasFoundUnresolvedFields = true;
            var compiler = TemplateEngineFactory.ForColumn(context.CurrentColumn.Guid);
            var templateSpec = context.CurrentColumn.TemplateSpecification;

            var templateContent = templateSpec.Template;
            if (templateSpec.TrimWhitespaces)
                templateContent = Regex.Replace(templateContent, @"(?:\r?\n)(?:\t| )*", " ", RegexOptions.Multiline);

            if (!compiler.TryCompile(templateContent))
            {
                Trace.TraceError("There is an syntax error in the Razor template for table '{0}', column '{1}', row {2}.", context.CurrentTable.Specification.Name, context.CurrentColumn.Name, context.CurrentRowIndex + 1);
                return new ResolvedValue(context.CurrentColumn.Type, null);
            }

            // Create the CURRENT model
            bool allResolved = true; // Will become false if not all columns are resolved yet.
            var model = new ExpandoObject() as IDictionary<string, object>;
            for (int index = 0; index < context.CurrentRow.Count; index++)
            {
                // Skip my own column
                if (index == context.CurrentColumnIndex) continue;

                // Get teh value of the column
                var valueOfRow = context.CurrentRow[index] as ResolvedValue;
                // Just ignore this field and try to run the razor template.
                if (valueOfRow == null)
                {
                    allResolved = false;
                    continue;
                }

                object valueOfRowResolved = null;
                // If the current column is indeed a resolved value, convert it to the proper type.
                if (valueOfRow != null)
                {
                    var currentColumn = context.CurrentTable.Content.Columns.Skip(index).First();

                    valueOfRowResolved = valueOfRow.Value;
                    var validator = DataValidatorFactory.Create(currentColumn.Type);
                    if (validator != null && valueOfRowResolved != null)
                        valueOfRowResolved = validator.Parse(valueOfRowResolved.ToString());
                }

                model.Add(context.CurrentTable.Content.Columns.Skip(index).First().Name, valueOfRowResolved);
            }

            // Create the whiteboard model
            var whiteboardModel = new ExpandoObject() as IDictionary<string, object>;
            context.CompleteDefinition.Whiteboard.ForEach(item => whiteboardModel.Add(item.Key, DataValidatorFactory.Create(item.Type).Parse(item.Value)));

            // Create the parameter model
            var parameterModel = new ExpandoObject() as IDictionary<string, object>;
            var localVariables = context.Value as IList<TypedVariable>;
            var defaultVariables = templateSpec.DefaultVariables;
            var allVariables = TypedVariableHelper.Merge(defaultVariables, localVariables);
            foreach (var variable in allVariables)
                parameterModel.Add(variable.Key, DataValidatorFactory.Create(variable.Type).Parse(variable.Value));

            // Build the full model
            string value;
            var dynamicModel = new DefaultTemplateModel
            {
                Current = model,
                Whiteboard = whiteboardModel,
                Parameters = parameterModel,
                Special = new SpecialTemplateModel
                {
                    TableName = context.CurrentTable.Specification.Name,
                    RowNumber = context.CurrentRowIndex + 1,
                    TotalRows = context.CurrentTable.Content.Rows.Count()
                },
                Actions = _actionTemplateModel
            };

            // Execute it
            if (!compiler.TryExecute(dynamicModel, out value))
            {
                if (!allResolved)
                {
                    Trace.TraceInformation("^ Cannot run template yet for '{0}.{1}', but will try again later. No worries :)", context.CurrentTable.Specification.Name, context.CurrentColumn.Name);
                    // Skip all rows for this column and this table
                    context.ResultSkipColumn = true;
                    return null;
                }
                Trace.TraceError("There is an runtime error in the Razor template for table '{0}', column '{1}', row {2}.", context.CurrentTable.Specification.Name, context.CurrentColumn.Name, context.CurrentRowIndex + 1);
            }
            return new ResolvedValue(context.CurrentColumn.Type, value);
        }
    }
}
