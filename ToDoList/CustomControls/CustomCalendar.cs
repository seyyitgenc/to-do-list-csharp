using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Globalization;

namespace ToDoList
{
    public partial class CustomCalendar : UserControl
    {
        //fields
        private int _rowCount;
        int LocationX = 0;
        int LocationY = 30;

        int monthCount = 0;

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

            //First Month
            lbl_Date.Text = Months[monthCount];
            lbl_Date.Location = new Point((pnl_Top.Width - lbl_Date.Width) / 2, 5);

            _rowCount = this.Width / 52;
            int padding = ((this.Width - (51 * _rowCount) + (1 * (_rowCount)))) / 2;

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
            for (int i = 1; i <= 31; i++)
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
                lbl_DayNum.Text = i.ToString();
                lbl_DayNum.Name = "LblDayNumber" + i;
                pnl_Content.Controls.Add(pnl_Day);
                pnl_Day.Controls.Add(lbl_DayNum);
                LocationX += 51;
            }
        }
        //Linklabel Click
        void LinkLbl_Right_Click(object sender, EventArgs e)
        {
            monthCount++;
            if (monthCount >= 12)
                monthCount = 0;
            lbl_Date.Text = Months[monthCount];
            lbl_Date.Location = new Point((pnl_Top.Width - lbl_Date.Width) / 2, 5);
        }

        //Linklabel Click
        void LinkLbl_Left_Click(object sender, EventArgs e)
        {
            monthCount--;
            if (monthCount <= 0)
                monthCount = 11;
            lbl_Date.Text = Months[monthCount];
            lbl_Date.Location = new Point((pnl_Top.Width - lbl_Date.Width) / 2, 5);
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
