using System.ComponentModel;

namespace DatabaseTestSetManager.Lib.Models
{
    public enum FieldBehavior
    {
        [Description("No special behavior")]
        None,
        [Description("Skip (DB generation)")]
        Generated,
        [Description("Relation to other object")]
        Relation,
        [Description("Razor templating")]
        RazorTemplate,
        [Description("Razor templating (shared)")]
        SharedRazorTemplate,
        [Description("Very very, very special")]
        Custom
    }
}
