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
        MainForm OwnerForm;
        static Bitmap image = new Bitmap(image);
        public static int pozR;
        public static int pozG;
        public static int pozB;

        public FormForColors(MainForm ownerForm)
        {
            this.OwnerForm = ownerForm; 
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormforColorsClosing); 
        }

        

        void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }

        private void FormforColorsClosing(object sender, EventArgs e)
        {
            if (MainForm.FullNameOfImage != "\0")
            {
                
                FromBitmapToScreen();
            }
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
               // image = Colors.Color_RGB(image, pozR, pozG, pozB);
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

        
    }
}
