using System.Collections.Generic;
using DatabaseTestSetManager.Lib.Models;

namespace DatabaseTestSetManager.Win.UI
{
    public partial class WhiteboardForm : DatabaseTestSetManager.Win.UI.ManageKeyValueForm
    {
        public WhiteboardForm()
        {
            InitializeComponent();

            LoadData(ApplicationState.Instance.Whiteboard);
        }

        protected override void SaveData(IList<TypedVariable> items)
        {
            ApplicationState.Instance.Whiteboard.Clear();
            items.ForEach(ApplicationState.Instance.Whiteboard.Add);
        }
    }
}
