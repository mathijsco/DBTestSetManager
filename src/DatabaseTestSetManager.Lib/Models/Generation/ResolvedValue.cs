namespace DatabaseTestSetManager.Lib.Models.Generation
{
    public class ResolvedValue
    {
        public ResolvedValue(FieldType fieldType, object value)
        {
            this.FieldType = fieldType;
            this.Value = value;
        }

        public FieldType FieldType { get; set; }

        public object Value { get; set; }
    }
}
