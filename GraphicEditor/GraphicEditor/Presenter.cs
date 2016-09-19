﻿using Figures.BL;
using System.Drawing;

namespace GraphicEditor
{
    class Presenter
    {    
        private Shapes shape;
        public IView View { get; set; }
        private Bitmap bmp;

        public void Initialize()
        {
            //canvas painting setting
            bmp = new Bitmap(View.pictureBox.Width, View.pictureBox.Height);            
            Shapes.CreateBMP(bmp);            
        }

        public void SelectFigure(string name)
        {
            switch (name)
            {
                case "Rectangle":
                    {
                        shape = new Figures.BL.Rectangle(View.background_Color);
                    }
                    break;
                case "Circle":
                    {
                        shape = new Circle(View.background_Color);
                    }
                    break;
                case "Line":
                    {
                        shape = new Line();
                    }
                    break;
                default: goto case "Rectangle";
            }

            if (shape != null)
                View.pictureBox.Image = shape.Draw(new Point(View.point_1_x, View.point_1_Y),
                   new Point(View.point_2_x, View.point_2_Y), View.selectedColor);
        }

        public void Clear_()
        {
            Picture.clearPicture();
            View.pictureBox.Image = bmp;
        }             

        public void LoadFile()
        {           
            LoadedPicture picture = new LoadedPicture();
            View.pictureBox.Image = picture.showPicture(View.fileName);
        }

        public void Save()
        {
            View.pictureBox.Image.Save(View.fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
          
        public void RandomDrawing()
        {
            shape = new Line();
            View.pictureBox.Image = shape.Draw(View.PrevPoint, View.CurrentPoint, View.selectedColor);
        }

        public void invertPict()
        {          
            int x,y;            
            try
            {
                for (x = 0; x < Picture.bmp.Width; x++)
                {
                    for (y = 0; y < Picture.bmp.Height; y++)
                    {
                        Color oldColor = Picture.bmp.GetPixel(x, y);
                        Color newColor;
                        newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                        Picture.bmp.SetPixel(x, y, newColor);
                        try
                        {
                            View.Invoke();
                        }
                        catch (System.InvalidOperationException ex)
                        {
                            View.ShowMessageBox(ex.ToString());
                        }
                    }                              
                }
            }
            catch (System.InvalidOperationException ex)
            {
                View.ShowMessageBox(ex.ToString());
            }           
        }
    }
}
    