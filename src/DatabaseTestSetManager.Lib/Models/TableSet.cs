using System.Diagnostics;

namespace DatabaseTestSetManager.Lib.Models
{
    [DebuggerDisplay("{Specification.Name}")]
    public class TableSet
    {
        public TableSpec Specification { get; set; }

        public ContentSet Content { get; set; }
    }
}
