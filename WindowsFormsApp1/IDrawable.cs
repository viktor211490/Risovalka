using System.Drawing;

namespace WindowsFormsApp1
{
    public interface IDrawable
    {
        void Drow(Graphics graphics);
        Color Color
        { get; set; }
    }
}
