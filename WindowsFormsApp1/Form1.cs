using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Picture pctr;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            pctr.DrawPicture();
        }
        int flag1 = 0;
        bool flag = false;

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            panel2.BackColor = colorDialog1.Color;
            if (pctr.Curfig.Selected)
                pctr.Curfig.Curfig.Color = colorDialog1.Color;

            panel1.Refresh();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog2.ShowDialog();
            panel3.BackColor = colorDialog2.Color;
            if (manipulator.Curfig != null)
                manipulator.Curfig.BackgroundColor = colorDialog2.Color;
            panel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            pctr.Clear();
            panel1.Refresh();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pctr.Curfig == null || e.Button != MouseButtons.Left)
            {
                return;
            }
            pctr.Curfig.Drag(e.X - oldX, e.Y - oldY);
            //manipulator.Curfig.Drag(e.X - oldX, e.Y - oldY);
            oldX = e.X;
            oldY = e.Y;
            panel1.Refresh();
        }
        int x0, y0;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
            if (radioButton4.Checked)
            {
                kind = 4;
            }
            if (kind == 0)
            {
                if (pctr.Curfig != null)
                {
                    if (manipulator.Shot(e.X, e.Y))
                    {
                        return;
                    }
                }
                Shape sh = pctr.Select(e.X, e.Y);
                manipulator = new Manipulator(sh);
                if (sh != null)
                {
                    manipulator.Shot(e.X, e.Y);
                }
                panel1.Refresh();
                return;
            }
            if (kind == 1)
            {
                Creator creator = new MyEllipseCreator(e.X, e.Y, panel2.BackColor, panel3.BackColor, 1, 1);
                Shape drawable = creator.Create();
                pctr.Add(drawable);
                panel1.Refresh();
                return;
            }
            if (kind == 2)
            {
                Creator creator = new MyRectangleCreator(e.X, e.Y, panel2.BackColor, panel3.BackColor, 1, 1);
                Shape drawable = creator.Create();
                pctr.Add(drawable);
                panel1.Refresh();
                return;
            }
            if (kind == 3)
            {
                Creator creator = new RhombusCreator(e.X, e.Y, panel2.BackColor, panel3.BackColor, 1, 1);
                Shape drawable = creator.Create();
                pctr.Add(drawable);
                panel1.Refresh();
                return;
            }

            flag = true;
            x0 = e.X;
            y0 = e.Y;
            //if (kind == 4)
            //{
            //    MyLine ln = new MyLine(x0, y0, e.X, e.Y, Color.Black);
            //    pctr.Add(ln);
            //    panel1.Refresh();
            //    return;
            //}
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
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
                    pctr.Deselect();
                }
                pctr.Deselect();
                panel1.Refresh();
            }
            //if (radioButton4.Checked)
            //{
            //    MyLine d = new MyLine(x0, y0, e.X, e.Y, Color.Black);
            //    flag = false;
            //    a.Add(d);
            //    panel1.Refresh();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                pctr.Save(saveFileDialog1.FileName);

            }
            catch
            { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                pctr.Load(openFileDialog1.FileName);
                panel1.Refresh();
            }
            catch
            { }
        }
        private int oldX = 0;
        private int oldY = 0;
        private int kind = 0;

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pctr.Curfig != null)
            {
                pctr.Remove(pctr.Curfig);
            }
            panel1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pctr = new Picture(panel1);
            panel2.BackColor = Color.Black;
        }
    }
}
