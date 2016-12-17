using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Graphic_Editor
{
    public class MovingAverage
    {

        public static Bitmap Blur(Bitmap image)
        {
            int x;
            int y;
            
            for (x = 1; x < image.Width - 1; x++)
                for (y = 0; y < image.Height; y++)
                {
                    Color c1 = image.GetPixel(x - 1, y);
                    Color c2 = image.GetPixel(x, y);
                    Color c3 = image.GetPixel(x + 1, y);


                    byte bR = (byte) ((c1.R + c2.R + c3.R)/3);
                    byte bG = (byte) ((c1.G + c2.G + c3.G)/3);
                    byte bB = (byte) ((c1.B + c2.B + c3.B)/3);


                    Color cBlured = Color.FromArgb(bR, bG, bB);

                    image.SetPixel(x, y, cBlured);

                }

            //vertical blur
            for (x = 0; x < image.Width; x++)
                for (y = 1; y < image.Height - 1; y++)
                {
                    Color c1 = image.GetPixel(x, y - 1);
                    Color c2 = image.GetPixel(x, y);
                    Color c3 = image.GetPixel(x, y + 1);


                    byte bR = (byte) ((c1.R + c2.R + c3.R)/3);
                    byte bG = (byte) ((c1.G + c2.G + c3.G)/3);
                    byte bB = (byte) ((c1.B + c2.B + c3.B)/3);


                    Color cBlured = Color.FromArgb(bR, bG, bB);

                    image.SetPixel(x, y, cBlured);

                }
            return image;
        }
    }
}
