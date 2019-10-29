using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    [Serializable]
    public class MyEllipse : Figure
    {
        public MyEllipse()
        {
        }
        public MyEllipse(int xx, int yy, Color color, Color bcolor, int ww, int hh) : base(xx, yy, color, bcolor, ww, hh)
        {
        }
        public override void Drow(Graphics g)
        {
            Pen pen = new Pen(color, 2);
            g.DrawEllipse(pen, x, y, width, height);
            g.FillEllipse(new SolidBrush(backgroundColor), x, y, width, height);
            base.Drow(g);
        }
        public override bool Touch(int xx, int yy)
        {
            throw new NotImplementedException();
        }
    }
}
