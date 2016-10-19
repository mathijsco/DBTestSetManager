using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Models
{
    public class TemplateSpec
    {
        public string Template { get; set; }

        public bool TrimWhitespaces { get; set; }

        public IList<TypedVariable> DefaultVariables { get; set; }
    }
}
