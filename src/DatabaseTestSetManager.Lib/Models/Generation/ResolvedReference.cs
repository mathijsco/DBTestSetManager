namespace DatabaseTestSetManager.Lib.Models.Generation
{
    public class ResolvedReference : ResolvedValue
    {
        public ResolvedReference(FieldType fieldType, object value, string tableName, string valueField, string lookupField, FieldType lookupFieldType, object lookupValue)
            : base(fieldType, value)
        {
            this.FieldType = fieldType;
            this.TableName = tableName;
            this.ValueField = valueField;
            this.LookupField = lookupField;
            this.LookupFieldType = lookupFieldType;
            this.LookupValue = lookupValue;
        }

        public string TableName { get; set; }

        public string ValueField { get; set; }

        public string LookupField { get; set; }

        public FieldType LookupFieldType { get; set; }

        public object LookupValue { get; set; }
    }
}
