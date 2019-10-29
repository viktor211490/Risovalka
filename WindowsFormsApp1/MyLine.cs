using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
        [Serializable]
    class MyLine : IDrawable
    {
        protected int x, y, x1, y1;
        protected Color color;
        public MyLine()
        {
            x = 0;
            y = 0;
            x1 = 0;
            y1 = 0;
            color = Color.Black;
        }
        public MyLine(int x, int y, int x1, int y1, Color c)
        {
            this.x = x;
            this.y = y;
            this.x1 = x1;
            this.y1 = y1;
            this.color = c;
        }
        public void Drow(Graphics g)
        {
            Pen p = new Pen(color, 4);
            Point[] point = new Point[2];
            point[0] = new Point(x, y);
            point[1] = new Point(x1, y1);
            g.DrawLine(p, point[0], point[1]);
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

    }
}
