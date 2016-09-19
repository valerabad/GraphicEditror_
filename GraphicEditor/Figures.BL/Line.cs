using System.Drawing;

namespace Figures.BL
{
    public class Line : Shapes
    {        
        public Line()
        {
            pen = new Pen(Color.Black);
            p1 = new Point(10, 10);
            p2 = new Point(50, 50);            
        }
       
        public override Bitmap Draw(Point p1, Point p2, Color color)
        {
            pen.Color = color;
            graph = Graphics.FromImage(bmp);
            graph.DrawLine(pen,p1, p2);
            return bmp;
        }          
    }
}
