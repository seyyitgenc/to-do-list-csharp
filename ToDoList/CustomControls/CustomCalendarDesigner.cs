using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
namespace ToDoList
{
    public partial class CustomCalendar
    {
        private Panel pnl_Content;
        private Panel pnl_Titlebar;

        void Render()
        {
            Handle_Load();

            this.BackColor = Color.CornflowerBlue;
            this.MaximumSize = new Size(width, height);
            this.Size = new Size(width, height);
            this.MinimumSize = new Size(width, height);
        }

        //Height Property
        public int Height_C
        {
            get { return height; }
            set { height = value; }
        }
        //Width Property
        public int Width_C
        {
            get { return width; }
            set { width = value; }
        }
        //RowCount Property
        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value; }
        }



    }
}
