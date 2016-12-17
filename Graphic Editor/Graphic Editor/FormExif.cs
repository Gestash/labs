using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class FormExif : Form
    {
        public FormExif(MainForm ownerForm)
        {
            InitializeComponent();
        }

        private void OutExif()
        {
            var openFile = new OpenFileDialog();
            openFile.ShowDialog();
            var imageOi = openFile.FileName;
            var image1 = new Bitmap(imageOi);
            MainForm.pictureBox1.Image = image1;



            label1.Text = "Path: " + imageOi;
            label2.Text = "Height: " + image1.Height;
            label3.Text = "Width: " + image1.Width;
            label4.Text = "Format: " + imageOi.Substring(imageOi.LastIndexOf(".") + 1);
        }
    }
}
