using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class FormForColors : Form
    {

        //public static Bitmap Image;// = new Bitmap(Image);
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
            if (MainForm.FullNameOfImage != "\0")
            {
                int poz = trackBar1.Value;
                pozR = poz;
                Colors.Color_RGB(Image, pozR, pozG, pozB);
                //Image = Colors.Color_RGB(Image, pozR, pozG, pozB);
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {


                int poz = trackBar1.Value;
                pozB = poz;
                Colors.Color_RGB(Image, pozR, pozG, pozB);
               Image = Colors.Color_RGB(Image, pozR, pozG, pozB);
            } 
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {


                int poz = trackBar2.Value;
                pozG = poz;
                Colors.Color_RGB(Image, pozR, pozG, pozB);
                //Image = Colors.Color_RGB(Image, pozR, pozG, pozB);
            } 
        }

        void FromBitmapToScreen()
        {
            _ownerForm.FromBitmapToScreen();
        }

        private void FormForColorsClosing(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {

                FromBitmapToScreen();
            }
        }


        
    }
}
