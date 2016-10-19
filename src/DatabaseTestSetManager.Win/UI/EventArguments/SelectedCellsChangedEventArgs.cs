using System;

namespace DatabaseTestSetManager.Win.UI.EventArguments
{
    public sealed class SelectedCellsChangedEventArgs : EventArgs
    {
        public SelectedCellsChangedEventArgs(int selectedCells)
        {
            this.SelectedCells = selectedCells;
        }

        public int SelectedCells { get; private set; }
    }
}
