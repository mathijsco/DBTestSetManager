using DatabaseTestSetManager.Win.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new MainForm();

            if (args.Length == 1)
                form.LoadFile(args[0]);

            Application.Run(form);
        }
    }
}
