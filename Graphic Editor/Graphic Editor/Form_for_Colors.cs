using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class Form_for_Colors : Form
    {
        MainForm OwnerForm;
        public Form_for_Colors(MainForm ownerForm)
        {
            this.OwnerForm = ownerForm;
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button_Click);
            this.FormClosing += new FormClosingEventHandler(Form_for_ColorsClosing);
        }
        //R
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (MainForm.full_name_of_image != "\0")
            {
                UInt32 p;
                for (int i = 0; i < MainForm.image.Height; i++)
                    for (int j = 0; j < MainForm.image.Width; j++)
                    {
                        p = Colors.Color_R(MainForm.pixel[i, j], trackBar1.Value, trackBar1.Maximum);
                        MainForm.FromOnePixelToBitmap(i, j, p);
                    }

                FromBitmapToScreen();
            }
        }
        //G
        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            if (MainForm.full_name_of_image != "\0")
            {
                UInt32 p;
                for (int i = 0; i < MainForm.image.Height; i++)
                    for (int j = 0; j < MainForm.image.Width; j++)
                    {
                        p = Colors.Color_G(MainForm.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
                        MainForm.FromOnePixelToBitmap(i, j, p);
                    }

                FromBitmapToScreen();
            }
        }
        
        //B
        private void trackBar3_Scroll_1(object sender, EventArgs e)
        {
            if (MainForm.full_name_of_image != "\0")
            {
                UInt32 p;
                for (int i = 0; i < MainForm.image.Height; i++)
                    for (int j = 0; j < MainForm.image.Width; j++)
                    {
                        p = Colors.Color_B(MainForm.pixel[i, j], trackBar3.Value, trackBar3.Maximum);
                        MainForm.FromOnePixelToBitmap(i, j, p);
                    }

                FromBitmapToScreen();
            }
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            if (MainForm.full_name_of_image != "\0")
            {
                for (int i = 0; i < MainForm.image.Height; i++)
                    for (int j = 0; j < MainForm.image.Width; j++)
                        MainForm.pixel[i, j] = (UInt32)(MainForm.image.GetPixel(j, i).ToArgb());
                trackBar1.Value = 0;
                trackBar2.Value = 0;
                trackBar3.Value = 0;
            }
        }

        //вывод изображения на экран
        void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }

        //обновление изображения в Bitmap и pictureBox при закрытии окна
        private void Form_for_ColorsClosing(object sender, System.EventArgs e)
        {
            if (MainForm.full_name_of_image != "\0")
            {
                MainForm.FromPixelToBitmap();
                FromBitmapToScreen();
            }
        }  
    }
}
