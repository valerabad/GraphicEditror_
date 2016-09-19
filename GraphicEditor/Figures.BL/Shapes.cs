using System.Drawing;

namespace Figures.BL
{
    public abstract class Shapes : Picture
    {        
        public Color color { get; set; }
        public Pen pen { get; set; }        
        public Point p1,p2;

        public abstract Bitmap Draw(Point p1, Point p2, Color color);        

        public static void CreateBMP(Bitmap bmp_)
        {
            bmp = bmp_;    
        }
    }       
}
