using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Lab1
{
    public partial class SmartphoneDevice : SmartDevice
    {
        
        public virtual void TakePhoto(Bitmap image)
        {
            if (MainForm.pictureBox1.InvokeRequired)
            {
                MainForm.pictureBox1.Invoke(new Action(() =>
                {
                    MainForm.pictureBox1.Image = null; 
                    MainForm.pictureBox1.Image = image;
                }));
            }
            else
            {
                MainForm.pictureBox1.Image = null;
                MainForm.pictureBox1.Image = image;
            }
        }

        public override void Property()
        {
            MainForm.Instance.Output("Это смартфон. Портативное устройство с множеством возможностей.");
        }
    }
}
