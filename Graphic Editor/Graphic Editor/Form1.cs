using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Graphic_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap image;
        public static Bitmap image1;
        public static string FullNameOfImage = "\0";

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FullNameOfImage = openFileDialog1.FileName;
                    image = new Bitmap(openFileDialog1.FileName);
                    image1 = new Bitmap(openFileDialog1.FileName);
                    Form1.picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Width = image.Width + 16;
                    this.Height = image.Height + 65;
                    Form1.picture.Size = image.Size;
                    picture.Image = image;
                    picture.Invalidate();


                    FileStream f = File.Open(FullNameOfImage, FileMode.Open);
                    BitmapDecoder decoder = JpegBitmapDecoder.Create(f, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                    BitmapMetadata metadata = (BitmapMetadata)decoder.Frames[0].Metadata;
                    // Получаем заголовок через поле класса
                    string title = metadata.Title;
                    // Получаем заголовок из XMP
                    string xmptitle = (string)metadata.GetQuery(@"/xmp/<xmpalt>dc:title");
                    // Получаем заголовок из EXIF
                    string exiftitle = (string)metadata.GetQuery(@"/app1/ifd/{ushort=40091}");
                    // Получаем заголовок из IPTC
                    string iptctitle = (string)metadata.GetQuery(@"/app13/irb/8bimiptc/iptc/object name");

                    BitmapMetadata md = new BitmapMetadata("jpg");
                    md.SetQuery(@"/xmp/<xmpalt>dc:title", xmptitle);
                    md.SetQuery(@"/app1/ifd/{ushort=40091}", exiftitle);
                    md.SetQuery(@"/app13/irb/8bimiptc/iptc/object name", iptctitle);
                    BitmapFrame frame = BitmapFrame.Create(decoder.Frames[0], decoder.Frames[0].Thumbnail, md, decoder.Frames[0].ColorContexts);
                    BitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(frame);
                    //FileStream of = File.Open(FullNameOfImage, FileMode.Create, FileAccess.Write);
                   // encoder.Save(of);
                    //of.Close();

                }
                catch
                {
                    FullNameOfImage = "\0";
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picture.Image != null)
            {
               
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
            picture.Image = image;
        }

        private void яркостьКонтрастностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBrightnessContrast BCForm = new FormBrightnessContrast(this);
            BCForm.ShowDialog();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                image = MovingAverage.Blur(image);
                FromBitmapToScreen();
            
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                image = Inverse.Invert(image);
                FromBitmapToScreen();
            
        }

        private void смещениеЦветовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormForColors ColorForm = new FormForColors(this);
            ColorForm.ShowDialog();
        }

       
    }
}
