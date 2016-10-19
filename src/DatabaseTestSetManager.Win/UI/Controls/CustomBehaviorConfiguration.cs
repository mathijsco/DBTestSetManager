using System;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls
{
    public partial class CustomBehaviorConfiguration : UserControl
    {
        public CustomBehaviorConfiguration()
        {
            InitializeComponent();
        }

        private void CustomBehaviorConfiguration_VisibleChanged(object sender, EventArgs e)
        {
            pictureBox1.Enabled = this.Visible;
        }
    }
}
