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
        //protected Shape currentFigure = null;
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
            return currentFigure;
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
                if (currentFigure == shape)
                {
                    currentFigure.Selected = false;
                    currentFigure = null;
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
                if (man.Curfig.Touch(posution_x,posution_y))
                {
                    return man.Curfig;
                }
            }
            foreach (Shape shape1 in arrayList)
            {
                if (shape1.Touch(posution_x, posution_y))
                {
                    man.Curfig = shape1;
                    return shape1;
                }

            }           
            return null;
        }
        public void Deselect()
        {
            if (currentFigure != null)
            {
                currentFigure.Selected = false;
                currentFigure = null;
            }

        }
        public void Save(string str)
        {
            if (currentFigure != null)
            {
                currentFigure.Selected = false;
                currentFigure = null;
            }
            BinaryFormatter binaryFormater = new BinaryFormatter();
            Stream stream = File.Create(str);
            binaryFormater.Serialize(stream, arrayList);
            stream.Close();
        }
        public void Load(string str)
        {
            if (currentFigure != null)
            {
                currentFigure.Selected = false;
                currentFigure = null;
            }
            BinaryFormatter binaryFormater = new BinaryFormatter();
            Stream stream = File.OpenRead(str);
            arrayList = (ArrayList)binaryFormater.Deserialize(stream);
            stream.Close();
        }
        public void Clear()
        {
            arrayList.Clear();
            currentFigure = null;
        }
        public void Delete()
        {
            if (currentFigure != null)
            {
                Remove(currentFigure);
            }
        }
    }
}
