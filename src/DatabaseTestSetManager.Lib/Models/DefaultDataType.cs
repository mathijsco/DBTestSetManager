using System.ComponentModel;

namespace DatabaseTestSetManager.Lib.Models
{
    public enum DefaultDataType
    {
        [Description("Static value")]
        Static,
        [Description("Static list")]
        StaticList,
        [Description("C# statement")]
        CSharp
    }
}
