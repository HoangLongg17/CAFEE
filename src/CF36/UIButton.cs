using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF36
{
    public class UIButton
    {
        public static void ReplaceStandardButtonsWithIcons(Form form, Image exitIcon, Image deleteIcon, Image refreshIcon)
        {
            ApplyToControlRecursive(form, exitIcon, deleteIcon, refreshIcon);
        }

        private static void ApplyToControlRecursive(Control parent, Image exitIcon, Image deleteIcon, Image refreshIcon)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn)
                {
                    string text = btn.Text.Trim().ToLower();

                    if (text == "thoát")
                    {
                        ApplyIcon(btn, exitIcon, "Thoát");
                    }
                    else if (text == "xóa")
                    {
                        ApplyIcon(btn, deleteIcon, "Xóa");
                    }
                    else if (text == "làm mới")
                    {
                        ApplyIcon(btn, refreshIcon, "Làm mới");
                    }
                }

                if (control.HasChildren)
                {
                    ApplyToControlRecursive(control, exitIcon, deleteIcon, refreshIcon);
                }
            }
        }

        private static void ApplyIcon(Button btn, Image icon, string tooltipText)
        {
            btn.Text = "";
            btn.Image = icon;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.DarkRed;

            ToolTip tip = new ToolTip();
            tip.SetToolTip(btn, tooltipText);
        }

    }
}
