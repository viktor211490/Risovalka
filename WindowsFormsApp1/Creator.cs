using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
  abstract class Creator
    {
        abstract public Shape Create();
    }
    class MyEllipseCreator : Creator
    {
        protected int position_x, position_y, width, height;
        protected Color color, bcolor;
        public MyEllipseCreator(int position_x, int position_y, Color color, Color bcolor, int width, int height)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.width = width;
            this.height = height;
            this.color = color;
            this.bcolor = bcolor;
        }

        public override Shape Create()
        {
            return new MyEllipse(position_x,position_y,color,bcolor,width,height);
        }
    }
    class MyRectangleCreator : Creator
    {
        protected int xx, yy, ww, hh;
        protected Color color, bcolor;
        public MyRectangleCreator(int xx, int yy, Color color, Color bcolor, int ww, int hh)
        {
            this.xx = xx;
            this.yy = yy;
            this.ww = ww;
            this.hh = hh;
            this.color = color;
            this.bcolor = bcolor;
        }

        public override Shape Create()
        {
            return new MyRectangle(xx, yy, color, bcolor, ww, hh);
        }
    }

    class RhombusCreator : Creator
    {
        protected int xx, yy, ww, hh;
        protected Color color, bcolor;
        public RhombusCreator(int xx, int yy, Color color, Color bcolor, int ww, int hh)
        {
            this.xx = xx;
            this.yy = yy;
            this.ww = ww;
            this.hh = hh;
            this.color = color;
            this.bcolor = bcolor;
        }

        public override Shape Create()
        {
            return new Rhombus(xx, yy, color, bcolor, ww, hh);
        }
    }
    class MyLineCreator : Creator
    {
        protected int xx, yy, ww, hh;
        protected Color color, bcolor;
        public MyLineCreator(int xx, int yy, int ww, int hh, Color color)
        {
            this.xx = xx;
            this.yy = yy;
            this.ww = ww;
            this.hh = hh;
            this.color = color;
            
        }

        public override Shape Create()
        {
            return new MyRectangle(xx, yy, color, bcolor, ww, hh);
        }
    }
}
