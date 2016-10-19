using System;

namespace DatabaseTestSetManager.Lib.Razor.Models
{
    public sealed class SpecialTemplateModel
    {
        public string TableName { get; set; }

        public int RowNumber { get; set; }

        public int TotalRows { get; set; }
    }
}
