using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graphic_Editor
{
    public class BrightnessContrast
    {
        public static Bitmap Bright_change(Bitmap image, int pozB, int l1)
        {
            int x;
            int y;

            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    int N = (100 / l1) * pozB; //кол-во процентов
                    //Пиксель изображения на замену
                    Color oldColor = image.GetPixel(x, y);
                    //Задание нового пикселя для замены старого
                    Color newColor;
                    //Задаем значение нового пикселя
                    int r = oldColor.R + N * 128 / 100;
                    int g = oldColor.G + N * 128 / 100;
                    int b = oldColor.B + N * 128 / 100;
                    // проверяем на переполнение
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;
                    newColor = Color.FromArgb(oldColor.A, r, g, b);

                    //Заменяем новый пиксель вместо старого
                    image.SetPixel(x, y, newColor);
                }
            }
            return image;
        }

        public static Bitmap Contrast_change(Bitmap image, int pozC, int l1)
        {
            int x;
            int y;

            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    int r, g, b;
                    int N = (100 / l1) * pozC;
                    Color oldColor = image.GetPixel(x, y);
                    //Задание нового пикселя для замены старого
                    Color newColor;
                    if (N >= 0)
                    {
                        if (N == 100) N = 99;
                        r = (oldColor.R * 100 - 128 * N) / (100 - N);
                        g = (oldColor.G * 100 - N * 128) / (100 - N);
                        b = (oldColor.B * 100 - N * 128) / (100 - N);
                    }
                    else
                    {
                        r = (oldColor.R * 100 - (-N) + 128 * (-N)) / 100;
                        g = (oldColor.G * 100 - (-N) + 128 * (-N)) / 100;
                        b = (oldColor.B * 100 - (-N) + 128 * (-N)) / 100;
                    }
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;
                    newColor = Color.FromArgb(oldColor.A, r, g, b);
                    image.SetPixel(x, y, newColor);
                }
                
            }
            return image;
        }
    }
}
