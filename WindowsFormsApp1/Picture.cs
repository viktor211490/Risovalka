using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Picture
    {
        protected ArrayList arayList = new ArrayList();
        protected Graphics graphics = null;
        protected Figure figure = null;
        public Picture(Control Control)
        {
            if (Control != null)
            {
                graphics = Control.CreateGraphics();
            }
        }
        public Picture()
        {
        }
        public Figure Curfig
        {
            get { return figure; }
            set { figure = value; }
        }
        public void Add(Figure Figure)
        {
            if (Figure != null)
            {
                arayList.Add(Figure);
                if (figure != null)
                {
                    figure.Selected = false;
                }
                Figure.Selected = true;
                figure = Figure;
            }
        }
        public void Remove(Figure figure)
        {
            if (figure != null)
            {
                if (this.figure == figure)
                {
                    this.figure.Selected = false;
                    this.figure = null;
                }
                arayList.Remove(figure);
            }
        }
        public void DrawPicture()
        {
            if (graphics != null)
            {
                foreach (Figure figure in arayList)
                {
                    figure.Drow(graphics);
                }
            }
        }
        public Figure Select(int xx, int yy)
        {
            Figure figure = null;
            Deselect();
            foreach (Figure s in arayList)
            {
                if (s.Touch(xx, yy))
                    figure = s;
            }
            if (figure != null)
            {
                figure.Selected = true;
                this.figure = figure;
            }
            return figure;
        }
        public void Deselect()
        {
            if (figure != null)
            {
                figure.Selected = false;
                figure = null;
            }
        }
        public void Save(string stroka)
        {
            if (figure != null)
            {
                figure.Selected = false;
                figure = null;
            }
            BinaryFormatter bnf = new BinaryFormatter();
            Stream st = File.Create(stroka);
            bnf.Serialize(st, arayList);
            st.Close();
        }
        public void Load(string @string)
        {
            if (figure != null)
            {
                figure.Selected = false;
                figure = null;
            }
            BinaryFormatter binaryFornater = new BinaryFormatter();
            Stream stream = File.OpenRead(@string);
            arayList = (ArrayList)binaryFornater.Deserialize(stream);
            stream.Close();
        }
        public void Clear()
        {
            arayList.Clear();
            figure = null;
        }
        public void Delete()
        {
            if (figure != null)
            {
                Remove(figure);
            }
        }
    }
}