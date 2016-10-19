using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;

namespace DatabaseTestSetManager.Win.UI.Controls.DefaultValuePanels
{
    public interface IDefaultValuePanel
    {
        IDefaultDataProvider Value { get; set; }

        bool Visible { get; set; }
    }
}
