using DatabaseTestSetManager.Win.UI.Controls.Modules;

namespace System.Windows.Forms
{
    /// <summary>
    /// Class with extension methods for all <see cref="Control"/> objects.
    /// </summary>
    public static class ControlModuleExtensions
    {
        /// <summary>
        /// Adds and starts a new module to the control.
        /// </summary>
        /// <typeparam name="TControl">The control type to be extended.</typeparam>
        /// <param name="control">The control to be extended</param>
        /// <param name="module">The module to add.</param>
        public static void AddModule<TControl>(this TControl control, IControlModule<TControl> module) where TControl : Control
        {
            module.Control = control;
            control.Disposed += (sender, e) => module.Unregister();
            module.Register();
        }

        /// <summary>
        /// Adds and starts multiple new modules to the control.
        /// </summary>
        /// <typeparam name="TControl">The control type to be extended.</typeparam>
        /// <param name="control">The control to be extended</param>
        /// <param name="module">The modules to add.</param>
        public static void AddModules<TControl>(this TControl control, params IControlModule<TControl>[] modules) where TControl : Control
        {
            foreach (var module in modules)
                AddModule<TControl>(control, module);
        }
    }
}
