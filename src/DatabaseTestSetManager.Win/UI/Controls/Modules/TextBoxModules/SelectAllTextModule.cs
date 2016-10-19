using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.Modules.TextBoxModules
{
    public class SelectAllTextModule : IControlModule<TextBox>
    {
        public TextBox Control { get; set; }

        public void Register()
        {
            this.Control.KeyDown += Control_KeyDown;
        }

        public void Unregister()
        {
            this.Control.KeyDown -= Control_KeyDown;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                this.Control.SelectAll();
                e.Handled = true;
            }
        }
    }
}
