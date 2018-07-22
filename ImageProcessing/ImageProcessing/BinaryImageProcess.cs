using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing {
    class BinaryImageProcess : Process {
        private Label label;
        private NumericUpDown edittext;
        private TrackBar trackbar;

        public BinaryImageProcess(Image image, PictureBox pictureBox, GroupBox groupBox) : base(image, pictureBox, groupBox) { }

        public override void ViewControls() {
            label = new Label();
            label.Text = "Threshold";
            label.Location = new Point(10, INTERVAL_Y * 1 - 15);
            label.Size = new Size(17, 17);

            edittext = new NumericUpDown();
            edittext.Value = 0;
            edittext.Increment = 1;
            edittext.Minimum = 0;
            edittext.Maximum = 100;
            edittext.Location = new Point(125, INTERVAL_Y * 1 - 15);
            edittext.Size = new Size(60, 24);
            edittext.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);

            trackbar = new TrackBar();
            trackbar.Value = 0;
            trackbar.Minimum = 0;
            trackbar.Maximum = 100;
            trackbar.Location = new Point(10, INTERVAL_Y * 2 - 30);
            trackbar.Size = new Size(175, 24);
            trackbar.TickStyle = TickStyle.None;
            trackbar.Scroll += new EventHandler(Trackbar_Scroll);
            trackbar.MouseUp += new MouseEventHandler(Trackbar_MouseUp);

            grpBox.Controls.Add(label);
            grpBox.Controls.Add(edittext);
            grpBox.Controls.Add(trackbar);
        }

        public override void ResetValue() {
            edittext.Value = 0;
            trackbar.Value = 0;
        }

        public override void Execute() {
            float threshold = (float)edittext.Value / 100.0F;
            Bitmap canvas = new Bitmap(b_img);
            Color color;

            for (Int32 y = 0; y < canvas.Size.Height; y++) {
                for (Int32 x = 0; x < canvas.Size.Width; x++) {
                    color = canvas.GetPixel(x, y);

                    float fTemp = color.GetBrightness();
                    if (fTemp > threshold) {
                        canvas.SetPixel(x, y, Color.Black);
                    }
                    else {
                        canvas.SetPixel(x, y, Color.White);
                    }
                }
            }
            a_img = canvas;
        }

        public void Trackbar_Scroll(object sender, EventArgs e) {
            edittext.Value = trackbar.Value;
        }

        public void Trackbar_MouseUp(object sender, MouseEventArgs e) {
            Convert();
        }

        public void NumericUpDown_ValueChanged(object sender, EventArgs e) {
            trackbar.Value = (int)edittext.Value;
        }
    }
}
