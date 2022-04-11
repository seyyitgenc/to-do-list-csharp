using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;

namespace ToDoList
{
    partial class MainForm : Form
    {
        private bool mouseDownTitle;
        private Point lastLocationTitle;
        int LocationX;
        int LocationY;
        //constructor
        public MainForm()
        {
            Render();
        }

        //for closing form
        void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        //for minimizing form
        void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //for moving form
        void lbl_TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownTitle)
            {
                Location = new Point(
                    (Location.X - lastLocationTitle.X) + e.X, (Location.Y - lastLocationTitle.Y) + e.Y);

                Update();
            }
        }
        void lbl_TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownTitle = false;
        }
        void lbl_TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTitle = true;
            lastLocationTitle = e.Location;
        }
        void Handle_Load(object sender, EventArgs e)
        {
            int padding = ((this.Width - ((this.Width / 7 - 5) * 7) - (1 * (7 - 1)))) / 2 + pnl_Left.Width;

            LocationX = padding;
            LocationY = 0;
            DateTime date = DateTime.Now;
            DateTime firstdayofMonth = new DateTime(date.Year, date.Month, 1);
            int dayCount = DateTime.DaysInMonth(date.Year, date.Month);
            for (int i = 0; i < dayCount; i++)
            {
                Panel pnl_Date = new Panel();
                Label lbl_Date = new Label();
                lbl_Date.Dock = DockStyle.Top;
                lbl_Date.Text = firstdayofMonth.ToString("dd MMM yyyy");
                lbl_Date.TextAlign = ContentAlignment.MiddleCenter;
                firstdayofMonth = firstdayofMonth.AddDays(1);
                lbl_Date.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
                if (i % 7 == 0 && i > 0)
                {
                    LocationY += this.Height / 5 - 7;
                    LocationX = padding;
                }

                pnl_Date.Size = new Size((this.Width - pnl_Left.Width) / 7 - 7, this.Height / 5 - 9);
                pnl_Date.Location = new Point(LocationX, LocationY);
                pnl_Date.Name = "PnlTest" + i;
                pnl_Date.BackColor = Color.CornflowerBlue;
                pnl_Date.BorderStyle = BorderStyle.FixedSingle;
                pnl_Date.Controls.Add(lbl_Date);
                pnl_Content.Controls.Add(pnl_Date);
                LocationX += (this.Width-pnl_Left.Width) / 7-5;
            }
        }
    }
}
