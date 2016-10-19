using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Models
{
    public class FullTestSet
    {
        public IList<TypedVariable> Whiteboard { get; set; }

        public IList<TableSet> Sets { get; set; }
    }
}
