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
    public partial class FormForColors : Form
    {

        readonly Form1 _ownerForm;
        public static int pozR;
        public static int pozG;
        public static int pozBl;
        public Bitmap Image;

        public FormForColors(Form1 ownerForm)
        {
            Image = Form1.image;
            _ownerForm = ownerForm;
            InitializeComponent();
            FormClosing += FormForColorsClosing;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            int poz = trackBar1.Value;
            pozR = poz;
            int l1= trackBar1.Maximum;
            Image = Colors.Color_RGB(Image, pozR, pozG, pozBl, l1);
            FromBitmapToScreen();
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            int poz = trackBar2.Value;
            pozG = poz;
            int l1 = trackBar1.Maximum;
            Image = Colors.Color_RGB(Image, pozR, pozG, pozBl, l1);
            FromBitmapToScreen();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {

            int poz = trackBar3.Value;
            pozBl = poz;
            int l1 = trackBar1.Maximum;
            Image = Colors.Color_RGB(Image, pozR, pozG, pozBl, l1);
            FromBitmapToScreen();
        }


        void FromBitmapToScreen()
        {
            _ownerForm.FromBitmapToScreen();
        }

        private void FormForColorsClosing(object sender, EventArgs e)
        {
            FromBitmapToScreen();

        }

      

    }
}
