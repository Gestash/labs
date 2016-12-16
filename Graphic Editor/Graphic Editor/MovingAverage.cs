using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Graphic_Editor
{
    public class MovingAverage
    {
        int x, y;
       
        public void Blur()
        {
            
            for (x = 1; x < newimg.Width - 1; x++)
            {
                for (y = 1; y < newimg.Height - 1; y++)
                {

                    int Intensivity = GetIntensivity(x - 1, y - 1);
                    Intensivity += GetIntensivity(x, y - 1);
                    Intensivity += GetIntensivity(x + 1, y - 1);
                    Intensivity += GetIntensivity(x - 1, y);
                    Intensivity += GetIntensivity(x + 1, y);
                    Intensivity += GetIntensivity(x - 1, y + 1);
                    Intensivity += GetIntensivity(x, y + 1);
                    Intensivity += GetIntensivity(x + 1, y + 1);
                    Intensivity /= 8;
                    Color newColor = Color.FromArgb(Intensivity, Intensivity, Intensivity);
                    newimg.SetPixel(x, y, newColor);
                }
            }
        }
        
        public int GetIntensivity(int x, int y)
        {
            Color pixelColor = newimg.GetPixel(x, y);
            var I = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
            return I;
        }
    }
}
