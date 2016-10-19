using System.ComponentModel;

namespace DatabaseTestSetManager.Lib.Models
{
    public enum FieldType
    {
        [Description("Text")]
        String,
        [Description("Number")]
        Number,
        [Description("Guid")]
        Guid,
        [Description("Date, time and time zone")]
        DataTimeOffset,
        [Description("Time offset")]
        TimeSpan,
        [Description("RAW output (BE CAREFUL!)")]
        Raw
    }
}