using DatabaseTestSetManager.Lib.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Elements
{
    public class DataGridViewTypedVariableCell : DataGridViewTextBoxCell
    {
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            var column = (DataGridViewTypedVariableColumn)this.OwningColumn;

            var list = value as IList<TypedVariable>;
            if (list == null || list.Count == 0) return null;

            var builder = new StringBuilder();
            bool first = true;
            foreach (var item in list)
            {
                if (item.Value == null) continue;

                if (!first) builder.Append(", ");
                else first = false;

                builder.Append(item.Key);
                builder.Append(": ");
                builder.Append(item.Value);
            }

            return first ? null : builder.ToString();
        }
    }
}
