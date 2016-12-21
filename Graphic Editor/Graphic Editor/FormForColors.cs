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

        readonly MainForm _ownerForm;
        public static int pozR;
        public static int pozG;
        public static int pozB;
        public Bitmap Image;

        public FormForColors(MainForm ownerForm)
        {
            Image = MainForm.image;
            _ownerForm = ownerForm;
            InitializeComponent();
            FormClosing += FormForColorsClosing;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            int poz = trackBar1.Value;
            pozR = poz;
            //Colors.Color_RGB(Image, pozR, pozG, pozB);
            Image = Colors.Color_RGB(Image, pozR, pozG, pozB);
            FromBitmapToScreen();
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            int poz = trackBar2.Value;
            pozG = poz;
            // Colors.Color_RGB(Image, pozR, pozG, pozB);
            Image = Colors.Color_RGB(Image, pozR, pozG, pozB);
            FromBitmapToScreen();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {

            int poz = trackBar1.Value;
            pozB = poz;
            //Colors.Color_RGB(Image, pozR, pozG, pozB);
            Image = Colors.Color_RGB(Image, pozR, pozG, pozB);
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
