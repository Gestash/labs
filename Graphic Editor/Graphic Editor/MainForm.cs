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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap bmpSave = (Bitmap)pictureBox1.Image;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)

                bmpSave.Save(sfd.FileName, pictureBox1.Image, ImageFormat.Bmp);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileStream fs = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                    this.pictureBox1.Size = img.Size;
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Invalidate();

                }
            
        }

    }
}
