using System.Drawing;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI
{
    internal static class CellStyles
    {
        // Orange
        public static readonly DataGridViewCellStyle RawStyle = new DataGridViewCellStyle()
        {
            ForeColor = Color.Black,
            BackColor = Color.FromArgb(255, 230, 200),
            SelectionForeColor = Color.White,
            SelectionBackColor = Color.FromArgb(255, 165, 70)
        };

        // Green
        public static readonly DataGridViewCellStyle TemplateStyle = new DataGridViewCellStyle()
        {
            ForeColor = Color.Black,
            BackColor = Color.FromArgb(210, 240, 210),
            SelectionForeColor = Color.White,
            SelectionBackColor = Color.FromArgb(110, 190, 110)
        };

        // Red
        public static readonly DataGridViewCellStyle ErrorStyle = new DataGridViewCellStyle()
        {
            ForeColor = Color.Black,
            BackColor = Color.FromArgb(240, 210, 210),
            SelectionForeColor = Color.White,
            SelectionBackColor = Color.FromArgb(190, 110, 110)
        };

        // Gray
        public static readonly DataGridViewCellStyle ReadOnlyStyle = new DataGridViewCellStyle()
        {
            ForeColor = Color.FromArgb(169, 169, 169),
            BackColor = Color.FromArgb(220, 220, 220),
            SelectionForeColor = Color.FromArgb(240, 240, 240),
            SelectionBackColor = Color.FromArgb(120, 120, 120)
        };
    }
}
