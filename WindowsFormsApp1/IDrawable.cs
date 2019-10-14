using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public interface IDrawable
    {
        void Drawing(Graphics graphics);
        Color Color
        { get; set; }
    }
}
