using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.Modules
{
    /// <summary>
    /// Class to extend existing controls with new functionality, which can hook-up on events.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public interface IControlModule<in TControl> where TControl : Control
    {
        /// <summary>
        /// The control that will be extended.
        /// </summary>
        TControl Control { set; }

        /// <summary>
        /// The module is now registering for the control.
        /// </summary>
        void Register();

        /// <summary>
        /// The mdule is now unregistering for the control, which will be a result of disposing the control.
        /// </summary>
        void Unregister();
    }
}
