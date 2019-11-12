using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    [Serializable]
    public abstract class Shape : IDrawable
    {
        protected int x, y,width,height;
        protected Color color, backgroundColor;
        protected int ActivePoint = -1;
        public Shape(int x,int y,Color color,Color backgroundColor,int ww,int hh)
        {
            ActivePoint = 3;
            this.x = x;
            this.y = y;
            this.width = ww;
            this.height = hh;
            this.color = color;
            this.backgroundColor = backgroundColor;
        }
        public Shape()
        {
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            color = Color.Black;
            backgroundColor = Color.Black;
        }
        public override string ToString()
        {
            return "Фигура"+" x="+x+" y="+y+ " h="+height+" w="+width;
        }
        public virtual void Drawing(Graphics graphics)
        {
            //if(selected)
            //{
            //    DrawFrame(graphics);
            //}
        }
        public int x_E
        {
            get { return x; }
            set { x = value; }
        }
        public int y_E
        {
            get { return y; }
            set { y = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }
        public int Width_E
        {
            get { return width; }
            set { /*if (value >= 1)*/ width = value; }
        }
        public int Height_E
        {
            get { return height; }
            set { /*if (value >= 1)*/ height = value; }
        }
       
        private void DrawFrame(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawRectangle(pen, x - 4 - 5, y - 4 - 5, 8, 8);
            graphics.DrawRectangle(pen, x + width + 2, y - 4 - 5, 8, 8);
            graphics.DrawRectangle(pen, x - 4 - 5, y + height + 10 - 4 - 5, 8, 8);
            graphics.DrawRectangle(pen, x + width + 2, y + height + 10 - 4 - 5, 8, 8);
            pen.DashStyle = DashStyle.Dash;
            pen.DashPattern = new float[2] { 7, 3 };
            graphics.DrawRectangle(pen, x-5, y-5, width+10, height+10);
        }
        public abstract bool Touch(int xx, int yy);
        
        public void Drag(int dx, int dy)
        {
            if (ActivePoint == -1)
            {
                return;
            }
            if (ActivePoint == 0)
            {
                x_E += dx;
                y_E += dy;
            }
            if (ActivePoint == 1)
            {
                Width_E -= dx;
                Height_E -= dy;
                x_E += dx;
                y_E += dy;
            }
            if (ActivePoint == 2)
            {
                Width_E += dx;
                Height_E -= dy;
                y_E += dy;
            }
            if (ActivePoint == 3)
            {
                Width_E += dx;
                Height_E += dy;
            }
            if (ActivePoint == 4)
            {
                Width_E -= dx;
                Height_E += dy;
                x_E += dx;
                // y += dy;
            }

        }
    }
}
