using System;

namespace DatabaseTestSetManager.Lib.Models
{
    public class RelationSpec
    {
        /// <summary>
        /// Table used where the data should be loaded from
        /// </summary>
        public Guid SourceTable { get; set; }
        
        /// <summary>
        /// Column used for the generation of the data
        /// </summary>
        public Guid ValueColumn { get; set; }

        /// <summary>
        /// Column used to lookup the ValueColumn on generation of the data
        /// </summary>
        public Guid LookupColumn { get; set; }

        /// <summary>
        /// Column used to display in the UI
        /// </summary>
        public Guid DisplayColumn { get; set; }
    }
}
