using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graphic_Editor
{
    public class BrightnessContrast
    {
        public static Bitmap Bright_change(Bitmap image, int poz, int lenght)
        {
            int x;
            int y;

            for (x = 1; x <= image.Width - 1; x++)
            {
                for (y = 1; y <= image.Height - 1; y += 1)
                {
                    int N = (100 / lenght) * poz; //кол-во процентов
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
    }
}
