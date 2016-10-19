using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Lib.Models.Generation;
using DatabaseTestSetManager.Lib.ScriptBuilders.CustomTemplateModels;

namespace DatabaseTestSetManager.Lib.ScriptBuilders
{
    public class SqlServerScriptBuilder : ScriptBuilderBase
    {
        public SqlServerScriptBuilder()
            : base(new SqlServerActionModel())
        {

        }

        protected override IList<GeneratedScript> DumpOutput(FullTestSet completeDefinition)
        {
            // INSERT INTO [table] ([col1],[col2],[col3]) VALUES
            // (1, 'ABC', '2016-03-01T18:00:00+01:00'),
            // (2, 'DEF', '2016-03-01T19:00:00+01:00')

            var result = new List<GeneratedScript>();
            foreach (var tableSet in completeDefinition.Sets)
            {
                var builder = new StringBuilder();

                // Some comment for this table
                builder.AppendFormat("-------------------------------------\r\n");
                builder.AppendFormat("-- TEST SET FOR TABLE [{0}]\r\n", tableSet.Specification.Name);
                builder.AppendFormat("-- GENERATED ON {0:yyyy-MM-dd}\r\n", DateTime.Now.Date);
                builder.AppendFormat("-------------------------------------\r\n");

                // Initial INSERT statement
                builder.AppendFormat("INSERT INTO [{0}] (", tableSet.Specification.Name);

                // Process the column names
                bool first = true;
                foreach (var columnSpec in tableSet.Content.Columns.Where(c => !c.NoExport && c.Behavior != FieldBehavior.Generated))
                {
                    builder.AppendFormat("{0}[{1}]", first ? string.Empty : ",", columnSpec.Name);
                    first = false;
                }
                builder.AppendLine(") VALUES");

                // Process the values
                first = true;
                foreach (var row in tableSet.Content.Rows)
                {
                    // Append ,\r\n(
                    builder.AppendFormat("{0}(", first ? string.Empty : ",\r\n");

                    int columnIndex = -1;
                    bool firstData = true;
                    foreach (var columnSpec in tableSet.Content.Columns)
                    {
                        columnIndex++;
                        if (columnSpec.NoExport) continue;
                        if (columnSpec.Behavior == FieldBehavior.Generated) continue;

                        var value = ValueToString(columnSpec.Type, columnSpec.Behavior, (ResolvedValue)row[columnIndex]);
                        builder.AppendFormat("{0}{1}", firstData ? string.Empty : ",", value);
                        firstData = false;
                    }

                    // Append the final closing bracket
                    builder.Append(")");
                    first = false;
                }
                builder.Append(";");
                builder.AppendLine();

                result.Add(new GeneratedScript
                {
                    Name = tableSet.Specification.Name,
                    Output = builder.ToString()
                });
            }

            return result;
        }


        private static string ValueToString(FieldType originalFieldType, FieldBehavior fieldBehavior, ResolvedValue resolvedValue)
        {
            // Return the static text NULL if the value is null.
            if (resolvedValue.Value == null)
                return "NULL";

            switch (fieldBehavior)
            {
                case FieldBehavior.Relation:
                    // Value == lookup column in case of relation
                    var resolvedReference = (ResolvedReference)resolvedValue;
                    var tableName = resolvedReference.TableName;
                    var selectField = resolvedReference.ValueField;
                    var whereField = resolvedReference.LookupField;

                    // If the lookup column is the same as the select, just use the value.
                    if (selectField == whereField)
                        return ValueToString(resolvedReference.FieldType, resolvedReference.Value);
                    // If the lookup and select columns are different, locate it in the DB.
                    else
                    {
                        var valueToLookup = ValueToString(resolvedReference.LookupFieldType, resolvedReference.LookupValue);
                        return $"(SELECT [{selectField}] FROM [{tableName}] WHERE [{whereField}]={valueToLookup})";
                    }

                default:
                    return ValueToString(originalFieldType, resolvedValue.Value);
            }
        }

        private static string ValueToString(FieldType originalFieldType, object value)
        {
            switch (originalFieldType)
            {
                case FieldType.String:
                    return "'" + EscapeString(value.ToString()) + "'";

                case FieldType.Number:
                    return value.ToString();

                case FieldType.TimeSpan:
                    return "'" + value.ToString() + "'";

                case FieldType.Guid:
                    // e9d55c6d-488f-429b-97a8-2e6b4b11f0e0
                    var guid = Guid.Parse(value?.ToString());
                    return $"'{guid}'";

                case FieldType.DataTimeOffset:
                    var dateTimeOffset = DateTimeOffset.Parse(value.ToString()).ToString("o");
                    return $"'{dateTimeOffset}'";

                case FieldType.Raw:
                    return value.ToString();

                default:
                    throw new NotSupportedException("Cannot convert the cell value to the field type " + originalFieldType + ".");
            }
        }

        private static string EscapeString(string input)
        {
            return input
                .Replace("'", "''") // single quote
                .Replace("\t", "'+CHAR(9)+'") // tab
                .Replace("\r", "'+CHAR(13)+'") // carriage return
                .Replace("\n", "'+CHAR(10)+'") // new line
                .Replace(")+''+CHAR(", ")+CHAR(") // Trim the excessive excape thingies.
            ;
        }
    }
}
