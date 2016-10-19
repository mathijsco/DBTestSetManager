using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Lib.Models.Generation;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using DatabaseTestSetManager.Lib.ScriptBuilders.CustomActionModels;

namespace DatabaseTestSetManager.Lib.ScriptBuilders
{
    public class CsvScriptBuilder : ScriptBuilderBase
    {
        public CsvScriptBuilder()
            : base(new DefaultActionModel())
        {

        }

        protected override IList<GeneratedScript> DumpOutput(FullTestSet completeDefinition)
        {
            var result = new List<GeneratedScript>();
            foreach (var tableSet in completeDefinition.Sets)
            {
                var builder = new StringBuilder();

                // Add headers
                bool firstColumn = true;
                foreach (var column in tableSet.Content.Columns.Where(c => !c.NoExport))
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        builder.Append(",");

                    builder.Append(ValueToString(FieldType.String, column.Name));
                }
                builder.AppendLine();

                // Add content
                foreach (var rowSet in tableSet.Content.Rows)
                {
                    var columnIndex = -1;
                    firstColumn = true;
                    foreach (var field in rowSet)
                    {
                        columnIndex++;
                        var columnSpec = tableSet.Content.Columns.Skip(columnIndex).First();
                        if (columnSpec.NoExport)
                            continue;

                        if (firstColumn)
                            firstColumn = false;
                        else
                            builder.Append(",");

                        builder.Append(ValueToString(columnSpec.Type, ((ResolvedValue)field).Value));
                    }
                    builder.AppendLine();
                }

                result.Add(new GeneratedScript
                {
                    Name = tableSet.Specification.Name,
                    Output = builder.ToString()
                });
            }

            return result;
        }

        private static string ValueToString(FieldType originalFieldType, object value)
        {
            var str = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            if (originalFieldType != FieldType.Raw && (str.Contains("\"") || str.Contains(",") || str.Contains("\r") || str.Contains("\n") || str.Contains("\t")))
                str = string.Concat("\"", str.Replace("\"", "\"\""), "\"");
            return str;
        }
    }
}
