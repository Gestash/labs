using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graphic_Editor
{
    public class Inverse
    {
        public static Bitmap Invert(Bitmap image)
        {
            
            int x;
            int y;

            for (x = 0; x <= image.Width - 1; x++)
            {
                for (y = 0; y <= image.Height - 1; y += 1)
                {
                    //Пиксель изображения на замену
                    Color oldColor = image.GetPixel(x, y);
                    //Задание нового пикселя для замены старого
                    Color newColor;
                    //Задаем значение нового пикселя
                    newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    //Заменяем новый пиксель вместо старого
                    image.SetPixel(x, y, newColor);
                }
            }
            //Возвращаем инвертированное изображение
            return image;
        }
        
    }
}
