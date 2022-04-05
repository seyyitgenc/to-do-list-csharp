using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoList
{
    partial class MainForm
    {
        //fields
        private Panel pnl_Content;
        private Panel pnl_Titlebar;

        private Button btn_Close;
        private Button btn_Minimize;

        CustomCalendar calendar = new CustomCalendar();

        private Label lbl_Title;
        void Render()
        {
            //MainForm Customization
            this.Size = new Size(1000, 700);
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.Padding = new Padding(2, 0, 2, 2);
            this.BackColor = Color.CornflowerBlue;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load+=Handle_Load;

            //Panel Customization
            pnl_Content = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DodgerBlue,
            };
            pnl_Titlebar = new Panel
            {
                Height = 30,
                Dock = DockStyle.Top,
                BackColor = Color.CornflowerBlue,
            };

            //Button customization
            btn_Close = new Button
            {
                Text = "X",
                Size = new Size(35, 30),
                MaximumSize = new Size(35, 30),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Dock = DockStyle.Right,
            };
            btn_Close.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 79, 95);
            btn_Close.FlatAppearance.BorderSize = 0;

            btn_Minimize = new Button
            {
                Text = "_",
                Size = new Size(35, 30),
                MaximumSize = new Size(35, 30),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point),
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            btn_Minimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 79, 95);
            btn_Minimize.FlatAppearance.BorderSize = 0;

            //Label Customization
            lbl_Title = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Main Form",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            //Event Handlers
            btn_Close.Click += Btn_Close_Click;
            btn_Minimize.Click += Btn_Minimize_Click;

            lbl_Title.MouseDown += lbl_TitleBar_MouseDown;
            lbl_Title.MouseUp += lbl_TitleBar_MouseUp;
            lbl_Title.MouseMove += lbl_TitleBar_MouseMove;

            //Adding Controls
            pnl_Titlebar.Controls.Add(lbl_Title);
            pnl_Titlebar.Controls.Add(btn_Minimize);
            pnl_Titlebar.Controls.Add(btn_Close);

            pnl_Content.Controls.Add(calendar);
            this.Controls.Add(pnl_Content);
            this.Controls.Add(pnl_Titlebar);
        }

        void Handle_Load(object sender, EventArgs e)
        {
        }

    }
}
