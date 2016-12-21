using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class FormExif : Form
    {
        //OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public FormExif(MainForm image)
        {
            InitializeComponent();
        }

        public void OutExif(MainForm image, MainForm FullNameOfImage)
        {
            //var image1 = new ImageFormat(Image);
           
            //label1.Text = "Path: " + image1;
            //label2.Text = "Height: " + Image.Height;
            //label3.Text = "Width: " + Image.Width;
            //label4.Text = "Format:" + full_name_of_image;
        }

    }
}
