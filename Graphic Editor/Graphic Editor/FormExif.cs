using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class FormExif : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public FormExif(MainForm image)
        {
            InitializeComponent();
        }

        private void OutExif(Bitmap image)
        {
           
            label1.Text = "Path: " + image;
            label2.Text = "Height: " + image.Height;
            label3.Text = "Width: " + image.Width;
            label4.Text = "Format:" + openFileDialog1.FileName;
        }

        
    }
}
