using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class UIText
    {
        public static void ApplyButtonTextStyle(Form form)
        {
            ApplyToControlRecursive(form);
        }

        private static void ApplyToControlRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn && !string.IsNullOrWhiteSpace(btn.Text))
                {
                    btn.Font = new Font("Segoe UI Black", 9, FontStyle.Regular);
                    btn.ForeColor = Color.White;
                    btn.Text = btn.Text.ToUpper();
                }
                else if (control is Label lbl && !string.IsNullOrWhiteSpace(lbl.Text) && lbl.Name != "lbChaoMung" && lbl.Name != "lblWelcome" && lbl.Name != "lblognhanvien")
                {
                    lbl.Font = new Font("Segoe UI Black", 9, FontStyle.Regular);
                    lbl.ForeColor = Color.Black;
                }

                // Đệ quy vào container control như TableLayoutPanel, Panel, GroupBox...
                if (control.HasChildren)
                {
                    ApplyToControlRecursive(control);
                }
            }
        }

    }
}
