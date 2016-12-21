using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Windows.Media.Imaging;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows; 

namespace Graphic_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        public static Bitmap image;

        public static string FullNameOfImage = "\0";

        public void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FullNameOfImage = openFileDialog1.FileName;
                    image = new Bitmap(openFileDialog1.FileName);
                    MainForm.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Width = image.Width + 16;
                    this.Height = image.Height + 65;
                    MainForm.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                   
                }
                catch
                {
                    FullNameOfImage = "\0";
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                //string format = full_name_of_image.Substring(full_name_of_image.Length - 4, 4);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
        //вывод на экран
        public void FromBitmapToScreen()
        {
            pictureBox1.Image = image;
        }

        private void выводEXIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormExif ExifForm = new FormExif(this);
            //ExifForm.ShowDialog();
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            MessageBox.Show("Выбран файл: " + openFileDialog1.FileName);
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FullNameOfImage != "\0")
            {
                image = Inverse.Invert(image);
                FromBitmapToScreen();
            }
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FullNameOfImage != "\0")
            {
                image = MovingAverage.Blur(image);
                FromBitmapToScreen();
            }
        }

        private void смещениецветовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormForColors colorForm = new FormForColors(this);
            colorForm.ShowDialog();
        }


        
    }
}
