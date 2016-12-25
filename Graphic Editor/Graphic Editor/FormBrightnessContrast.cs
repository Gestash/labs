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
    public partial class FormBrightnessContrast : Form
    {
        readonly Form1 _ownerForm;
        public static int pozB;
        public static int pozC;
        public Bitmap Image;

        public FormBrightnessContrast(Form1 ownerForm)
        {
            Image = Form1.image;
            _ownerForm = ownerForm;
            InitializeComponent();
            FormClosing += FormForColorsClosing;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int poz1 = trackBar1.Value;
            pozB = poz1;
            int l1 = trackBar1.Maximum;
            Image = BrightnessContrast.Bright_change(Image, pozB, l1);
            FromBitmapToScreen();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int poz2 = trackBar2.Value;
            pozC = poz2;
            int l1 = trackBar1.Maximum;
            Image = BrightnessContrast.Contrast_change(Image, pozC, l1);
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
