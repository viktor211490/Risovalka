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
    public class MyRectangle: Figure
    {

        public MyRectangle()
        {
        }
        public MyRectangle(int xx, int yy, Color color, Color bcolor, int ww, int hh) : base(xx, yy, color, bcolor, ww, hh)
        {
        }
        public override string ToString()
        {
            return "Прямоугольник" + " x=" + x + " y=" + y + " h=" + height + " w=" + width;
        }
        public override void Drow(Graphics graphics)
        {

            Pen pen = new Pen(color, 2);
           
            graphics.DrawRectangle(pen, x, y, width, height);
            graphics.FillRectangle(new SolidBrush(backgroundColor), x, y, width, height);
            base.Drow(graphics);
        }
        public override bool Touch(int xx, int yy)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(new Rectangle(x, y, width, height));
            return graphicsPath.IsVisible(xx, yy);
        }
    }
}
