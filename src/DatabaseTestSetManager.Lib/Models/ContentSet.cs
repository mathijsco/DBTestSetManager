using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Models
{
    public class ContentSet
    {
        public IEnumerable<ColumnSpec> Columns { get; set; }

        public IEnumerable<ContentRow> Rows { get; set; }
    }
}
