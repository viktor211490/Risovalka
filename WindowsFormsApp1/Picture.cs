using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace WindowsFormsApp1
{
    class Picture
    {
        protected ArrayList arrayList = new ArrayList();
        protected Graphics graphics = null;
        protected Manipulator man;
        public Picture(Control control)
        {
            if (control != null)
            {
                graphics = control.CreateGraphics();
            }
        }
        public Picture()
        {

        }
        public Shape TakeCurrentFugure()
        {
            return man.manCurfig;
        }
        public ArrayList TakeArrayList()
        {
            return arrayList;
        }
        public Manipulator Curfig
        {
            get { return man; }
        }
        public void Add(Shape shape)
        {
            if (shape != null)
            {
                arrayList.Add(shape);
                //if (currentFigure != null)
                //{
                //    currentFigure.Selected = false;
                //}
                //shape.Selected = true;
                //currentFigure = shape;
            }
        }
        public void Remove(Shape shape)
        {
            if (shape != null)
            {
                if (man.manCurfig == shape)
                {
                    man.manCurfig = null;
                }
                arrayList.Remove(shape);
            }
        }
        public void DrawPicture()
        {
            if (graphics != null)
            {
                foreach (Shape sh in arrayList)
                {
                    sh.Drawing(graphics);
                }
                man.Drawing(graphics);
            }
        }
        public Shape Select(int posution_x, int posution_y)
        {

            if (man.Selected)
            {
                if (man.manCurfig.Touch(posution_x,posution_y))
                {
                    return man.manCurfig;
                }
            }
            foreach (Shape shape1 in arrayList)
            {
                if (shape1.Touch(posution_x, posution_y))
                {
                    man.manCurfig = shape1;
                    return shape1;
                }

            }           
            return null;
        }
        public void Clear()
        {
            arrayList.Clear();
            man.manCurfig = null;
        }
        public void Delete()
        {
            if (man.manCurfig != null)
            {
                Remove(man.manCurfig);
            }
        }
    }
}
