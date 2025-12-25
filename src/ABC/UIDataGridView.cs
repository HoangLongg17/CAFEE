using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class UIDataGridView
    {
        public static void FormatDataGridView(DataGridView dgv)
        {
            // Phủ toàn bộ vùng hiển thị
            dgv.Dock = DockStyle.Fill;

            // Cột tự giãn đều theo chiều ngang khung
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cho phép cuộn nếu nội dung vượt quá
            dgv.ScrollBars = ScrollBars.Both;

            // Tương tác người dùng
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Căn giữa và xuống dòng nếu cần
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Font và chiều cao dòng
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.RowTemplate.Height = 30;

            // Màu sắc
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.LightGray;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }

    }
}
