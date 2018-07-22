using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing {
    abstract class Process {
        public const int INTERVAL_Y = 40;
        public Bitmap b_img;
        public Bitmap a_img;
        public PictureBox picBox;
        public GroupBox grpBox;
        public abstract void ViewControls();
        public abstract void Execute();
        public abstract void ResetValue();

        public Process(Image image, PictureBox pictureBox, GroupBox groupBox) {
            if (image != null) {
                b_img = new Bitmap(image);
                picBox = pictureBox;
                grpBox = groupBox;
            }
        }

        public void ResetBitmap(Image image) {
            if (image != null) {
                b_img = new Bitmap(image);
                a_img = null;
            }
        }

        public void ResetGrp() {
            while(grpBox.Controls.Count > 0) {
                grpBox.Controls.Remove(grpBox.Controls[0]);
            }
        }

        public void Convert() {
            Execute();
            picBox.Visible = true;
            picBox.Image = a_img;
        }

        public void GetOutput() {
            if (b_img != null) {
                picBox.Image = null;
                ResetGrp();
                ViewControls();
                //Convert();
            }
        }
    }
}
