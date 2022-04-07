﻿using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Globalization;

namespace ToDoList
{
    public partial class CustomCalendar : UserControl
    {
        //fields
        DateTime date = DateTime.Now;

        private int _rowCount;
        int LocationX = 0;
        int LocationY = 30;

        string[] Months = DateTimeFormatInfo.CurrentInfo.MonthNames;
        string[] Days = DateTimeFormatInfo.CurrentInfo.DayNames;

        public CustomCalendar()
        {
            Render();
        }
        //Load Event
        void Handle_Load(object sender, EventArgs e)
        {
            linkLbl_Left.Location = new Point(((pnl_Top.Width - linkLbl_Left.Width) / 2) - 100, 5);
            linkLbl_Right.Location = new Point(((pnl_Top.Width - linkLbl_Right.Width) / 2) + 100, 5);
            Generate_Panels();
            reValue_Panels();
        }

        void Generate_Panels()
        {
            LocationY = 30;
            _rowCount = this.Width / 52;
            int padding = ((this.Width - (50 * _rowCount) - (1 * (_rowCount-1)))) / 2;

            //Dynamic Day Names
            for (int i = 0; i < 7; i++)
            {
                Label lbl_DayName = new Label();
                Panel pnl_DayName = new Panel();
                //dynamic label
                lbl_DayName.Name = "DayName" + i;
                lbl_DayName.Text = TruncateAtWord(Days[i], 3);
                lbl_DayName.Dock = DockStyle.Fill;
                lbl_DayName.TextAlign = ContentAlignment.MiddleCenter;
                //dynamic panel
                if (i == 0)
                    LocationX = padding;

                pnl_DayName.Location = new Point(LocationX, 0);
                pnl_DayName.Size = new Size(51, 20);
                pnl_DayName.Name = "PnlDayName" + i;
                pnl_DayName.Controls.Add(lbl_DayName);
                pnl_Content.Controls.Add(pnl_DayName);
                LocationX += 51;
            }
            LocationX = 0;

            //Dynamic Day Panels
            for (int i = 1; i <= 42; i++)
            {
                Panel pnl_Day = new Panel();
                Label lbl_DayNum = new Label();

                //dynamic panel
                pnl_Day.Name = "PnlDays" + i;
                pnl_Day.Click += Pnl_Day_Click;
                pnl_Day.BorderStyle = BorderStyle.FixedSingle;

                if (i == 1)
                    LocationX = padding;

                pnl_Day.Location = new Point(LocationX, LocationY);
                pnl_Day.Size = new Size(50, 50);

                if (i % _rowCount == 0)
                {
                    LocationX = padding - 51;
                    LocationY += 51;
                }
                //dynamic label
                lbl_DayNum.Name = "LblDayNumber" + i;
                pnl_Content.Controls.Add(pnl_Day);//panel
                pnl_Day.Controls.Add(lbl_DayNum);//label
                LocationX += 51;
            }
        }
        void reValue_Panels()
        {
            //Month Names
            lbl_Date.Text = Months[date.Month - 1];
            lbl_Date.Location = new Point((pnl_Top.Width - lbl_Date.Width) / 2, 5);

            Panel pnl_Day = new Panel();
            Label lbl_DayNum = new Label();

            DateTime firstdayofMonth = new DateTime(date.Year, date.Month, 1);
            int DayCount = DateTime.DaysInMonth(date.Year, date.Month);
            int firstdayofWeek = Convert.ToInt32(firstdayofMonth.DayOfWeek);

            for (int i = 7; i <= pnl_Content.Controls.Count - 1; i++)
            {
                Panel p = pnl_Content.Controls[i] as Panel;
                Label l = p.Controls[0] as Label;

                if (i - 6 <= firstdayofWeek || DayCount == 0)
                {
                    p.BackColor = Color.HotPink;
                    l.Text = "";
                }
                else
                {
                    p.BackColor = Color.Transparent;
                    p.Visible = true;
                    p.Enabled = true;
                    l.Text = (i - firstdayofWeek - 6).ToString();
                    DayCount--;
                }
            }
        }
        //Linklabel Click
        void LinkLbl_Right_Click(object sender, EventArgs e)
        {
            date = date.AddMonths(1);
            reValue_Panels();
        }
        //Linklabel Click
        void LinkLbl_Left_Click(object sender, EventArgs e)
        {
            date = date.AddMonths(-1);
            reValue_Panels();
        }
        //truncate string
        public string TruncateAtWord(string input, int length)
        {
            if (input == null || input.Length < length)
                return input;
            int iNextSpace = input.LastIndexOf(" ", length, StringComparison.Ordinal);
            return string.Format("{0}…", input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }
        void Pnl_Day_Click(object sender, EventArgs e)
        {
            Panel pnl = (Panel)sender;
            if (pnl.BackColor == Color.Red)
                pnl.BackColor = Color.Transparent;
            else
                pnl.BackColor = Color.Red;
        }
    }
}