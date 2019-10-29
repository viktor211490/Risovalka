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
    class Rhombus: Figure
    {
            
        public Rhombus()
        {
        }
        public Rhombus(int xx, int yy, Color color, Color bcolor, int ww, int hh) : base(xx, yy, color, bcolor, ww, hh)
        {
        }
        public override string ToString()
        {
            return "Ромб" + " x=" + x + " y=" + y + " h=" + height + " w=" + width;
        }
        public override void Drow(Graphics graphics)
        {
            Pen pen = new Pen(color, 2);
            Point[] point=new Point[4];
            point[0] = new Point(x+width/2, y);
            point[1] = new Point(x + width, y + height / 2);
            point[3] = new Point(x,y+height/2);
            point[2] = new Point(x + width / 2, y + height);
            graphics.DrawPolygon(pen,point);
            graphics.FillPolygon(new SolidBrush(backgroundColor), point);
            base.Drow(graphics);
        }
        public override bool Touch(int xx, int yy)
        {
             Point[] p=new Point[4];
            p[0] = new Point(x+width/2, y);
            p[1] = new Point(x + width, y + height / 2);
            p[3] = new Point(x,y+height/2);
            p[2] = new Point(x + width / 2, y + height);
            GraphicsPath g = new GraphicsPath();
            g.AddPolygon(p);
            return g.IsVisible(xx,yy);
        }
    }
}
