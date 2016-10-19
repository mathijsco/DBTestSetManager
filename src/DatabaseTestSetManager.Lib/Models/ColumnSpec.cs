using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;
using System;

namespace DatabaseTestSetManager.Lib.Models
{
    public class ColumnSpec
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public bool AllowNull { get; set; }

        public bool MustBeUnique { get; set; }

        public bool NoExport { get; set; }

        public FieldType Type { get; set; }

        public FieldBehavior Behavior { get; set; }

        public DefaultDataType DefaultDataType { get; set; }

        public IDefaultDataProvider DefaultDataProvider { get; set; }

        public RelationSpec RelationSpecification { get; set; }

        public TemplateSpec TemplateSpecification { get; set; }

        public CustomBehaviorSpec CustomBehaviorSpecification { get; set; }
    }
}
