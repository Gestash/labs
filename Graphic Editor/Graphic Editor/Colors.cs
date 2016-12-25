using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graphic_Editor
{
    public static class Colors
    {
       
        
        //цветовой баланс RGB
        public static Bitmap Color_RGB(Bitmap image, int pozR, int pozG, int pozBl, int l1)
        {
           
            int x;
            int y;

            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    //Пиксель изображения на замену
                    Color oldColor = image.GetPixel(x, y);
                    //Задание нового пикселя для замены старого
                    Color newColor;

                    int Nr = (100 / l1) * pozR* 128 / 100;

                    //Задаем значение нового пикселя R компоненты
                    int r = oldColor.R + Nr * 128 / 100;
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    
                    
                    //Задаем значение нового пикселя G компоненты
                    int Ng = (100 / l1) * pozG * 128 / 100;
                    int g = oldColor.G + Ng * 128 / 100;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    
                    //Задаем значение нового пикселя B компоненты
                    int Nb = (100 / l1) * pozBl * 128 / 100;
                    int b = oldColor.B + Nb * 128 / 100;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;
                    

                    
                    //Заменяем новый пиксель вместо старого
                    newColor = Color.FromArgb(oldColor.A, r, g, b);
                    image.SetPixel(x, y, newColor);
                }
            }
            return image;
        }

    }
  }

