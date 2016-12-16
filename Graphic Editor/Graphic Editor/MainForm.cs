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

namespace Graphic_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static Bitmap image;
        public static string full_name_of_image = "\0";
        public static UInt32[,] pixel;

        

        public void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    full_name_of_image = open_dialog.FileName;
                    image = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //this.Width = image.Width + 40;
                    //this.Height = image.Height + 75;
                    //this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate(); 
                    //получение матрицы пикселей
                    pixel = new UInt32[image.Height, image.Width];
                    for (int y = 0; y < image.Height; y++)
                         for (int x = 0; x < image.Width; x++)
                            pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());
                }
                catch
                {
                    full_name_of_image = "\0";
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

        //public void OutExif()
        //{
        //    pictureBox1.Image = image;
        //    //FileStream f = File.Open("Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*", FileMode.Open);
        //    BitmapDecoder decoder = JpegBitmapDecoder.Create(image, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
        //    BitmapMetadata metadata = (BitmapMetadata)decoder.Frames[0].Metadata;
        //    // Получаем заголовок через поле класса
        //    string title = metadata.Title;
        //    // Получаем заголовок из XMP
        //    string xmptitle = (string)metadata.GetQuery(@"/xmp/<xmpalt>dc:title");
        //    // Получаем заголовок из EXIF
        //    string exiftitle = (string)metadata.GetQuery(@"/app1/ifd/{ushort=40091}");
        //    // Получаем заголовок из IPTC
        //    string iptctitle = (string)metadata.GetQuery(@"/app13/irb/8bimiptc/iptc/object name");

        //    BitmapMetadata md = new BitmapMetadata("jpg");
        //    md.SetQuery(@"/xmp/<xmpalt>dc:title", xmptitle);
        //    md.SetQuery(@"/app1/ifd/{ushort=40091}", exiftitle);
        //    md.SetQuery(@"/app13/irb/8bimiptc/iptc/object name", iptctitle);
        //    BitmapFrame frame = BitmapFrame.Create(decoder.Frames[0], decoder.Frames[0].Thumbnail, md, decoder.Frames[0].ColorContexts);
        //    BitmapEncoder encoder = new JpegBitmapEncoder();
        //    encoder.Frames.Add(frame);
        //    FileStream of = File.Open("test2.jpg", FileMode.Create, FileAccess.Write);
        //    encoder.Save(of);
        //    //of.Close();
        //}
        
       
        //преобразование из UINT32 to Bitmap
        public static void FromPixelToBitmap()
        {
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));
        }

        //преобразование из UINT32 to Bitmap по одному пикселю
        public static void FromOnePixelToBitmap(int x, int y, UInt32 pixel)
        {
            image.SetPixel(y, x, Color.FromArgb((int)pixel));
        }

        //вывод на экран
        public void FromBitmapToScreen()
        {
            pictureBox1.Image = image;
        }

        private void выводEXIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // OutExif();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();

        }

        
    }
}
