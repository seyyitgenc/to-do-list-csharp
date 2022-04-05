using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace ToDoList
{
    public partial class CustomCalendar : Control
    {
        //fields
        public int rowCount;
        public int width = 400;
        public int height = 400;

        int LocationX = 0;
        int LocationY = 10;

        public CustomCalendar()
        {
            Render();
        }

        void Handle_Load()
        {
            rowCount = this.width / 52;
            for (int i = 1; i <= 31; i++)
            {
                Panel pnl_Day = new Panel();
                Label lbl_Day = new Label();

                //dynamic panel
                pnl_Day.Name = "Days" + i;
                pnl_Day.Click += Pnl_Day_Click;
                pnl_Day.BorderStyle = BorderStyle.FixedSingle;
                pnl_Day.Location = new Point(LocationX, LocationY);
                pnl_Day.Size = new Size(50, 50);

                LocationX += 51;

                if (i % rowCount == 0)
                {
                    LocationX = 0;
                    LocationY += 51;
                }

                lbl_Day.Text = i.ToString();
                lbl_Day.Name = "Days" + i;
                this.Controls.Add(pnl_Day);
                pnl_Day.Controls.Add(lbl_Day);
            }
        }

        void Pnl_Day_Click(object sender, EventArgs e)
        {
            Panel pnl = (Panel)sender;
            pnl.BackColor = Color.Red;
        }
    }

}
