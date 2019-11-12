using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Picture pctr;
        int flag1 = 0;
        bool flag = false;
        int x0, y0;
        private int oldX = 0;
        private int oldY = 0;
        private int kind = 0;
        Shape shape;
        Manipulator manipulator;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pctr = new Picture(panel1);
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            pctr.DrawPicture();
        }
        private void Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            if (pctr.Curfig.Selected)
            {
                pctr.Curfig.manCurfig.Color = colorDialog1.Color;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            pctr.Clear();
            panel1.Refresh();
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pctr.Curfig == null || e.Button != MouseButtons.Left)
            {
                return;
            }
            pctr.Curfig.Drag(e.X - oldX, e.Y - oldY);
            oldX = e.X;
            oldY = e.Y;
            panel1.Refresh();
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;
            if (radioButton5.Checked)
                kind = 0;
            if (radioButton1.Checked)
            {
                kind = 1;
            }
            if (radioButton2.Checked)
            {
                kind = 2;
            }
            if (radioButton3.Checked)
            {
                kind = 3;
            }
            //if (kind == 0)
            //{
            //    if (pctr.Curfig != null)
            //    {
            //        if (shape.Shot(e.X, e.Y))
            //        {
            //            return;
            //        }
            //    }
            //    Shape sh = pctr.Select(e.X, e.Y);
            //    shape = new Manipulator(sh);
            //    if (sh != null)
            //    {
            //        shape.Shot(e.X, e.Y);
            //    }
            //    panel1.Refresh();
            //    return;
            //}
            if (kind == 1)
            {
                Creator creator = new MyEllipseCreator(e.X, e.Y, Color.Black, Color.Black, 1, 1);
                Shape drawable = creator.Create();
                pctr.Add(drawable);
                panel1.Refresh();
                return;
            }
            if (kind == 2)
            {
                Creator creator = new MyRectangleCreator(e.X, e.Y, Color.Black, Color.Black, 1, 1);
                Shape drawable = creator.Create();
                pctr.Add(drawable);
                panel1.Refresh();
                return;
            }
            if (kind == 3)
            {
                Creator creator = new RhombusCreator(e.X, e.Y, Color.Black, Color.Black, 1, 1);
                Shape drawable = creator.Create();
                pctr.Add(drawable);
                panel1.Refresh();
                return;
            }
            flag = true;
            x0 = e.X;
            y0 = e.Y;
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (kind != 0)
            {
                if (kind == 2)
                {
                    if (pctr.Curfig.Width_E < 0 || pctr.Curfig.Height_E < 0)
                    {
                        if (pctr.Curfig.Width_E < 0)
                        {
                            pctr.Curfig.Width_E = Math.Abs(pctr.Curfig.Width_E);
                            pctr.Curfig.x_E = pctr.Curfig.x_E - pctr.Curfig.Width_E;
                        }
                        if (pctr.Curfig.Height_E < 0)
                        {
                            pctr.Curfig.Height_E = Math.Abs(pctr.Curfig.Height_E);
                            pctr.Curfig.y_E = pctr.Curfig.y_E - pctr.Curfig.Height_E;
                        }
                    }
                }
                panel1.Refresh();
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (pctr.Curfig != null)
            {
                pctr.Remove(pctr.Curfig);
            }
            panel1.Refresh();
        }
    }
}
