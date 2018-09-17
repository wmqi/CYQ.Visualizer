using CYQ.Data.Table;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace CYQ.Visualizer
{
    internal static class FormCreate
    {
        public static Form CreateForm(string title)
        {
            Form form = new Form();
            form.Text = title;
            form.ClientSize = new Size(600, 400);
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.HorizontalScroll.Enabled = true;
            form.VerticalScroll.Enabled = true;
            return form;
        }
        public static DataGridView CreateGrid(Form form)
        {
            DataGridView dg = new DataGridView();
            form.Controls.Add(dg);
            form.StartPosition = FormStartPosition.CenterScreen;
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            form.Icon = icon;
            Init(dg);
            dg.AutoSize = true;

            StatusBar sb = new StatusBar();
            LinkLabel label = new LinkLabel();
            label.Width = 400;
            label.LinkBehavior = LinkBehavior.HoverUnderline;
            label.LinkColor = Color.Black;
            label.Text = "  Author：路过秋天 : http://cyq1162.cnblogs.com";
            label.TextAlign = ContentAlignment.MiddleLeft;
            sb.Dock = DockStyle.Bottom;
            //sb.Controls.Add(label);
            label.Click += sb_Click;
            //form.Controls.Add(sb);
            return dg;
        }

        private static void Init(DataGridView dg)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dg.AutoGenerateColumns = true;
            dg.BackgroundColor = System.Drawing.Color.White;
            dg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dg.DefaultCellStyle = dataGridViewCellStyle3;
            dg.Dock = System.Windows.Forms.DockStyle.Fill;
            dg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dg.Location = new System.Drawing.Point(0, 0);
            dg.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dg.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dg.RowTemplate.Height = 20;
            dg.ReadOnly = true;
            dg.Dock = DockStyle.Fill;
            dg.ScrollBars = ScrollBars.Both;
            dg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dg_CellDoubleClick);
        }

        private static void dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGridView)
            {
                var cell = dataGridView[e.ColumnIndex, e.RowIndex];

            }
        }

        static void sb_Click(object sender, EventArgs e)
        {
            StartHttp("http://cyq1162.cnblogs.com");
        }
        #region 默认浏览器打开网址
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(
            IntPtr hwnd,
            string lpOperation,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            ShowCommands nShowCmd);
        public enum ShowCommands : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }
        /// <summary>
        /// 用默认浏览器打开网址
        /// </summary>
        private static void StartHttp(string url)
        {
            try
            {
                ShellExecute(IntPtr.Zero, "open", url, "", "", ShowCommands.SW_SHOWNOACTIVATE);
            }
            catch
            {
                System.Diagnostics.Process.Start("IEXPLORE.EXE", url);
            }
        }
        #endregion
        private static void AutoSizeColumn(DataGridView dgv)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgv.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgv.Size.Width)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgv.Columns[0].Frozen = true;
                if (dgv.Columns.Count > 1)
                {
                    //冻结某列 从左开始 0，1，2
                    dgv.Columns[1].Frozen = true;
                }
            }
            else
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }
        public static void BindTable(IDialogVisualizerService windowService, MDataTable dt, string title)
        {
            if (dt == null) { return; }
            if (string.IsNullOrEmpty(title))
            {
                title = string.Format("TableName : {0}    Rows： {1}    Columns： {2}", dt.TableName, dt.Rows.Count, dt.Columns.Count);
            }
            if (dt.Rows.Count > 200)
            {
                dt = dt.Select(200, null);
                title = title + " Show: Top 200 Rows";
            }
            Form form = FormCreate.CreateForm(title);
            DataGridView dg = FormCreate.CreateGrid(form);
            try
            {
                //插入行号
                MCellStruct ms = new MCellStruct("[No.]", System.Data.SqlDbType.Int);
                dt.Columns.Insert(0, ms);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0].Value = i + 1;
                }
                dt.Bind(dg);
                AutoSizeColumn(dg);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            windowService.ShowDialog(form);
        }
    }
}
