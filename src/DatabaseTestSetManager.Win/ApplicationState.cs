using DatabaseTestSetManager.Lib.Models;
using System.Collections.Generic;

namespace DatabaseTestSetManager.Win
{
    internal class ApplicationState
    {
        public static readonly ApplicationState Instance = new ApplicationState();

        private ApplicationState() { }

        public IList<TableSet> CurrentDataSet { get; set; } = new List<TableSet>();

        public IList<TypedVariable> Whiteboard { get; set; } = new List<TypedVariable>();
    }
}
