using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class UIButton
    {
        public static void ReplaceStandardButtonsWithIcons(Form form, Image exitIcon, Image deleteIcon, Image refreshIcon, Image doneIcon)
        {
            ApplyToControlRecursive(form, exitIcon, deleteIcon, refreshIcon, doneIcon);
        }

        private static void ApplyToControlRecursive(Control parent, Image exitIcon, Image deleteIcon, Image refreshIcon, Image doneIcon)
        {
            foreach (Control control in parent.Controls)
            {

                if (control is Button btn)
                {
                    string text = btn.Text.Trim().ToLower();

                    if (btn.Name != "btnPassword" && btn.Name != "btnAnHien" && btn.Name != "btnTim")
                    {
                        btn.BackColor = Color.DarkRed;
                    }
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
                    else if (btn.Name.Equals("btnLuu", StringComparison.OrdinalIgnoreCase)
                    || btn.Name.Equals("btnXacNhan", StringComparison.OrdinalIgnoreCase) || btn.Name.Equals("btnThem", StringComparison.OrdinalIgnoreCase))
                    {
                        ApplyIcon(btn, doneIcon, "Hoàn tất");
                    }
                    if (btn.Name != "btnPassword" && btn.Name != "btnAnHien" && btn.Name != "btnTim")
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Cursor = Cursors.Hand;
                        // Hover effect
                        btn.MouseEnter += (s, e) => btn.BackColor = Color.Firebrick;
                        btn.MouseLeave += (s, e) => btn.BackColor = Color.DarkRed;

                        // Click effect
                        btn.MouseDown += (s, e) => btn.BackColor = Color.Maroon;
                        btn.MouseUp += (s, e) => btn.BackColor = Color.DarkRed;
                    }
                    // Tooltip nếu có icon
                    if (string.IsNullOrWhiteSpace(btn.Text) && btn.Image != null)
                    {
                        ToolTip tip = new ToolTip();
                        tip.SetToolTip(btn, btn.Name.Replace("btn", "").Replace("_", " "));
                    }

                }

                if (control.HasChildren)
                {
                    ApplyToControlRecursive(control, exitIcon, deleteIcon, refreshIcon, doneIcon);
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
