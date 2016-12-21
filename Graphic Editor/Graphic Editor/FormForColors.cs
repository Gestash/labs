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

        //public static Bitmap image;// = new Bitmap(image);
        MainForm OwnerForm = new MainForm();
        public static int pozR;
        public static int pozG;
        public static int pozB;
      

        public FormForColors(MainForm ownerForm)
        {
            Bitmap image = new Bitmap();
            this.OwnerForm = ownerForm; 
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormForColorsClosing); 
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {


                int poz = trackBar1.Value;
                pozR = poz;
                Colors.Color_RGB(image, pozR, pozG, pozB);
                //image = Colors.Color_RGB(image, pozR, pozG, pozB);
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {


                int poz = trackBar1.Value;
                pozB = poz;
                Colors.Color_RGB(image, pozR, pozG, pozB);
               image = Colors.Color_RGB(image, pozR, pozG, pozB);
            } 
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {


                int poz = trackBar2.Value;
                pozG = poz;
                Colors.Color_RGB(image, pozR, pozG, pozB);
                //image = Colors.Color_RGB(image, pozR, pozG, pozB);
            } 
        }

        void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
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
