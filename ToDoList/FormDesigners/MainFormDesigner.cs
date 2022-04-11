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
        private Panel pnl_TaskTitle;
        private Panel pnl_Left;

        private Button btn_Close;
        private Button btn_Minimize;

        CustomCalendar calendar = new CustomCalendar();

        private TableLayoutPanel layoutPanelTasks;

        private Label lbl_Title;
        private Label lbl_TaskTitle;
        private Button btn_AddTask;

        void Render()
        {
            //MainForm Customization
            this.Size = new Size(1300, 740);
            this.MaximumSize = new Size(1300, 740);
            this.MinimumSize = new Size(1300, 740);
            this.Padding = new Padding(2, 0, 2, 2);
            this.BackColor = Color.CornflowerBlue;
            this.FormBorderStyle = FormBorderStyle.None;
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
            pnl_Left = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.Green,
            };

            pnl_TaskTitle = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.Red,
                Height = 50,
            };
            layoutPanelTasks = new TableLayoutPanel()
            {
                ColumnCount = 1,
                RowCount = 1,
                Dock = DockStyle.Fill,
                BackColor = Color.Blue,
                AutoSize = true,
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

            btn_AddTask = new Button
            {
                Text = "Add Task",
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            //Label Customization
            lbl_Title = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Main Form",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            lbl_TaskTitle = new Label
            {
                Text = "Tasks",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            //Event Handlers
            this.Load += Handle_Load;

            btn_Close.Click += Btn_Close_Click;
            btn_Minimize.Click += Btn_Minimize_Click;

            lbl_Title.MouseDown += lbl_TitleBar_MouseDown;
            lbl_Title.MouseUp += lbl_TitleBar_MouseUp;
            lbl_Title.MouseMove += lbl_TitleBar_MouseMove;

            btn_AddTask.Click += Btn_AddTask_Click;

            //Adding Controls
            pnl_Titlebar.Controls.Add(lbl_Title);
            pnl_Titlebar.Controls.Add(btn_Minimize);
            pnl_Titlebar.Controls.Add(btn_Close);

            pnl_Content.Controls.Add(pnl_Left);

            pnl_Left.Controls.Add(layoutPanelTasks);
            pnl_Left.Controls.Add(btn_AddTask);
            pnl_Left.Controls.Add(pnl_TaskTitle);

            pnl_TaskTitle.Controls.Add(lbl_TaskTitle);

            this.Controls.Add(pnl_Content);
            this.Controls.Add(pnl_Titlebar);
        }

        int id = 0;
        //Task Generator
        void Btn_AddTask_Click(object sender, EventArgs e)
        {
            TableLayoutRowStyleCollection styles = layoutPanelTasks.RowStyles;
            Panel pnl_task = new Panel();
            Label lbl_task = new Label();
            pnl_task.Name = "Tasks" + id;
            lbl_task.Name = "Tasks" + id;
            lbl_task.Text = "Tasks" + id;
            pnl_task.Dock = DockStyle.Top;
            pnl_task.BackColor = Color.Red;
            pnl_task.Click += Pnl_Task_Click;
            layoutPanelTasks.Controls.Add(pnl_task, 0, id);
            layoutPanelTasks.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            layoutPanelTasks.RowCount += 1;
            id++;
            pnl_task.Controls.Add(lbl_task);
        }

        int i = 0;
        void Pnl_Task_Click(object sender, EventArgs e)
        {
            Panel p = pnl_Content.Controls[1] as Panel;
            Panel pnl = (sender) as Panel;
            pnl.Parent = p;
            string numb = pnl.Name.Trim('T','a','s','k','s');
            layoutPanelTasks.RowStyles[Convert.ToInt32(numb)].Height = 0;
            i++;
        }
    }
}
