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
    public class MyEllipse: Shape
    {

        public MyEllipse()
        {
        }
        public MyEllipse(int xx, int yy, Color color, Color bcolor, int ww, int hh) : base(xx, yy, color, bcolor, ww, hh)
        {            
        }
        public override string ToString()
        {
             return "Эллипс" + " x=" + x + " y=" + y + " h=" + height+ " w=" + width;
        }
        public override void Drawing(Graphics g)
        {
            Pen pen = new Pen(color, 2);
            g.DrawEllipse(pen,x, y, width, height);
            g.FillEllipse(new SolidBrush(backgroundColor), x, y, width, height);
            base.Drawing(g);
        }
        public override bool Touch(int xx,int yy)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(x,y,width,height);
            return graphicsPath.IsVisible(xx, yy);
        }
    }
}
