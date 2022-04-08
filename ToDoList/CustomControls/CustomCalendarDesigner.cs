using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class CustomCalendar
    {
        //fields
        private Panel pnl_Top;
        private Panel pnl_Content;
        private LinkLabel linkLbl_Left;
        private LinkLabel linkLbl_Right;

        private Label lbl_Date;
        private Label lbl_Year;
        private Button btn_send = new Button();

        void Render()
        {
            //control customization
            this.BackColor = Color.CornflowerBlue;

            //panel customization
            pnl_Top = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.BlueViolet,
            };
            pnl_Content = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.MediumVioletRed,
            };
            //linklabel customization
            linkLbl_Left = new LinkLabel
            {
                Text = "<",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                AutoSize = true,
                LinkColor = Color.Black,
                VisitedLinkColor = Color.Black,
                ActiveLinkColor = Color.DarkGray,
                LinkBehavior = LinkBehavior.NeverUnderline,
            };

            linkLbl_Right = new LinkLabel
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Text = ">",
                LinkColor = Color.Black,
                VisitedLinkColor = Color.Black,
                ActiveLinkColor = Color.DarkGray,
                AutoSize = true,
                LinkBehavior = LinkBehavior.NeverUnderline,
            };

            //label customization
            lbl_Date = new Label
            {
                Text = "test",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                AutoSize = true,
            };

            lbl_Year = new Label
            {
                Location = new Point(330, 5),
                Text = "test",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                AutoSize = true,
            };

            btn_send.Location = new Point(300, 400);
            btn_send.Text = "test";

            linkLbl_Left.Click+=LinkLbl_Left_Click;
            linkLbl_Right.Click+=LinkLbl_Right_Click;

            this.Load += Handle_Load;
            this.Controls.Add(pnl_Content);
            this.Controls.Add(pnl_Top);

            pnl_Content.Controls.Add(btn_send);

            pnl_Top.Controls.Add(lbl_Year);
            pnl_Top.Controls.Add(lbl_Date);
            pnl_Top.Controls.Add(linkLbl_Right);
            pnl_Top.Controls.Add(linkLbl_Left);
        }
    }
}
