using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Razor.Models
{
    public sealed class DefaultTemplateModel
    {
        public IDictionary<string, object> Current { get; set; }

        public IDictionary<string, object> Whiteboard { get; set; }

        public IDictionary<string, object> Parameters { get; set; }

        public SpecialTemplateModel Special { get; set; }

        public IActionTemplateModel Actions { get; set; }
    }
}
