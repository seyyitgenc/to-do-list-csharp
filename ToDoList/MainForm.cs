using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace ToDoList
{
    partial class MainForm : Form
    {
        private bool mouseDownTitle;
        private Point lastLocationTitle;
        CustomCalendar cc = new CustomCalendar();

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

    }
}
