using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Picture picture;
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            _ = panel1.CreateGraphics();
            picture.DrawPicture();
        }
        int flag1 = 0;
        bool flag = false;
        int x0, y0;
        private int oldX = 0;
        private int oldY = 0;
        private int kind = 0;
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            //colorDialog1.ShowDialog();
            //panel2.BackColor = colorDialog1.Color;
            //if (pctr.Curfig.Selected)
            //    pctr.Curfig.Curfig.Color = colorDialog1.Color;

            //panel1.Refresh();
        }
        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            //colorDialog2.ShowDialog();
            //panel3.BackColor = colorDialog2.Color;
            //var manipulator = new Manipulator(pctr.Curfig);
            //if (manipulator.Curfig != null)
            //    manipulator.Curfig.BackgroundColor = colorDialog2.Color;
            //panel1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            picture.Clear();
            panel1.Refresh();
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            var manipulator = new Manipulator(picture.Curfig);
            oldX = e.X;
            oldY = e.Y;
            if (radioButton5.Checked) kind = 0;
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
                if (manipulator.TakeFigure != null)
                {
                    if (manipulator.DrowHitFigure(e.X, e.Y))
                    {
                        return;
                    }
                }
                Figure figure = picture.Select(e.X, e.Y);
                manipulator = new Manipulator(figure);
                if (figure != null)
                {
                    manipulator.DrowHitFigure(e.X, e.Y);
                }
                panel1.Refresh();
                return;
            }
            if (kind == 1)
            {
                var creator = new MyEllipseCreator(e.X, e.Y, panel2.BackColor, panel3.BackColor, 1, 1);
                picture.Add(creator.Create());
                panel1.Refresh();
                return;
            }
            if (kind == 2)
            {
                var creator = new MyRectangleCreator(e.X, e.Y, panel2.BackColor, panel3.BackColor, 1, 1);
                picture.Add(creator.Create());
                panel1.Refresh();
                return;
            }
            if (kind == 3)
            {
                return;
            }
            flag = true;
            x0 = e.X;
            y0 = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (picture.Curfig == null || e.Button != MouseButtons.Left)
            {
                return;
            }
            picture.Curfig.Drag(e.X - oldX, e.Y - oldY);
            oldX = e.X;
            oldY = e.Y;
            panel1.Refresh();
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _ = panel1.CreateGraphics();
            if (kind != 0)
            {
                if (kind == 2)
                {
                    if (picture.Curfig.Width_E < 0 || picture.Curfig.Height_E < 0)
                    {
                        if (picture.Curfig.Width_E < 0)
                        {
                            picture.Curfig.Width_E = Math.Abs(picture.Curfig.Width_E);
                            picture.Curfig.Position_X = picture.Curfig.Position_X - picture.Curfig.Width_E;
                        }
                        if (picture.Curfig.Height_E < 0)
                        {
                            picture.Curfig.Height_E = Math.Abs(picture.Curfig.Height_E);
                            picture.Curfig.Position_Y = picture.Curfig.Position_Y - picture.Curfig.Height_E;
                        }
                    }
                    //pctr.Deselect();
                }
                //pctr.Deselect();
                panel1.Refresh();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (picture.Curfig != null)
            {
                picture.Remove(picture.Curfig);
            }
            panel1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            picture = new Picture(panel1);
            panel2.BackColor = Color.Black;
        }
    }
}
