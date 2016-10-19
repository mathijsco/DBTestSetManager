using System;
using System.Drawing;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI
{
    public static class ConfigToFormExtensions
    {
        public static void LoadState(this Form form)
        {
            var settings = AssemblyConfig.Load();

            // Apply the size
            Rectangle metric;
            if (settings.WindowMetrics.TryGetValue(form.Name, out metric))
            {
                form.StartPosition = FormStartPosition.Manual;
                form.DesktopBounds = metric;
            }

            form.FormClosing += FormClosing;
        }

        public static void ForceSaveState(this Form form)
        {
            var settings = AssemblyConfig.Load();

            if (form.WindowState == FormWindowState.Normal)
                settings.WindowMetrics[form.Name] = form.DesktopBounds;
        }

        private static void FormClosing(object sender, EventArgs e)
        {
            var form = (Form)sender;

            form.FormClosing -= FormClosing;
            form.ForceSaveState();
        }
    }
}
