using System;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public class Manipulator : Figure
    {
        Figure _shape;
        public Manipulator(Figure shape)
        {
            _shape = shape;
        }
        public bool Selected
        {
            get { return _shape != null; }
        }
        public Figure TakeFigure
        {
            get { return _shape; }
            set { _shape = value; }
        }
        public void SetShape(Figure shape)
        {
            _shape = shape;
        }
        public override bool Touch(int xx, int yy)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(x, y, width, height);
            return graphicsPath.IsVisible(xx, yy);
        }
        public bool DrowHitFigure(int xx, int yy)
        {
            if (Width_E < 0 || Height_E < 0)
            {
                if (Width_E < 0)
                {
                    Width_E = Math.Abs(Width_E);
                    Position_X -= Width_E;
                }
                if (Height_E < 0)
                {
                    Height_E = Math.Abs(Height_E);
                    Position_Y -= Height_E;
                }
            }
            ActivePoint = -1;
            if (xx > x - 5 && xx < x + width + 5 && yy > y - 5 && yy < y + height + 5)
            {
                ActivePoint = 0;
            }
            else if (xx > x - 9 && xx < x - 1 && yy > y - 9 && yy < y - 1)
            {
                ActivePoint = 1;
            }
            else if (xx > x + width + 2 && xx < x + width + 10 && yy > y - 9 && yy < y - 1)
            {
                ActivePoint = 2;
            }
            else if (xx > x + width + 2 && xx < x + width + 10 && yy > y + height + 10 - 4 - 5 && yy < height + y + 9)
            {
                ActivePoint = 3;
            }
            else if (xx > x - 9 && xx < x - 1 && yy > y + height + 10 - 4 - 5 && yy < height + y + 9)
            {
                ActivePoint = 4;
            }
            return (ActivePoint != -1);
        }
        public Figure GetShape()
        {
            return _shape;
        }
    }
}
