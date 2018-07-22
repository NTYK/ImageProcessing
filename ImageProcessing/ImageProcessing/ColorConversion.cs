using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing {
    class ColorConversion : Process{
        private Label label1, label2, label3;
        private NumericUpDown edittext1, edittext2, edittext3;
        private TrackBar trackbar1, trackbar2, trackbar3;

        public ColorConversion(Image image, PictureBox pictureBox, GroupBox groupBox):base(image, pictureBox, groupBox) { }

        public override void ViewControls() {
            label1 = new Label();
            label1.Text = "R";
            label1.Location = new Point(10, INTERVAL_Y * 1 - 15);
            label1.Size = new Size(17, 17);

            edittext1 = new NumericUpDown();
            edittext1.Value = 0;
            edittext1.Increment = 1;
            edittext1.Minimum = -100;
            edittext1.Maximum = 100;
            edittext1.Location = new Point(125, INTERVAL_Y * 1 - 15);
            edittext1.Size = new Size(60, 24);
            edittext1.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);

            trackbar1 = new TrackBar();
            trackbar1.Value = 0;
            trackbar1.Minimum = -100;
            trackbar1.Maximum = 100;
            trackbar1.Location = new Point(10, INTERVAL_Y * 2 - 30);
            trackbar1.Size = new Size(175, 24);
            trackbar1.TickStyle = TickStyle.None;
            trackbar1.Scroll += new EventHandler(Trackbar_Scroll);
            
            label2 = new Label();
            label2.Text = "G";
            label2.Location = new Point(10, INTERVAL_Y * 3 - 15);
            label2.Size = new Size(17, 17);

            edittext2 = new NumericUpDown();
            edittext2.Value = 0;
            edittext2.Increment = 1;
            edittext2.Minimum = -100;
            edittext2.Maximum = 100;
            edittext2.Location = new Point(125, INTERVAL_Y * 3 - 15);
            edittext2.Size = new Size(60, 24);
            edittext2.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);

            trackbar2 = new TrackBar();
            trackbar2.Value = 0;
            trackbar2.Minimum = -100;
            trackbar2.Maximum = 100;
            trackbar2.Location = new Point(10, INTERVAL_Y * 4 - 30);
            trackbar2.Size = new Size(175, 24);
            trackbar2.TickStyle = TickStyle.None;
            trackbar2.Scroll += new EventHandler(Trackbar_Scroll);

            label3 = new Label();
            label3.Text = "B";
            label3.Location = new Point(10, INTERVAL_Y * 5 - 15);
            label3.Size = new Size(17, 17);

            edittext3 = new NumericUpDown();
            edittext3.Value = 0;
            edittext3.Increment = 1;
            edittext3.Minimum = -100;
            edittext3.Maximum = 100;
            edittext3.Location = new System.Drawing.Point(125, INTERVAL_Y * 5 - 15);
            edittext3.Size = new System.Drawing.Size(60, 24);
            edittext3.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);

            trackbar3 = new TrackBar();
            trackbar3.Value = 0;
            trackbar3.Minimum = -100;
            trackbar3.Maximum = 100;
            trackbar3.Location = new Point(10, INTERVAL_Y * 6 - 30);
            trackbar3.Size = new Size(175, 24);
            trackbar3.TickStyle = TickStyle.None;
            trackbar3.Scroll += new EventHandler(Trackbar_Scroll);

            grpBox.Controls.Add(label1);
            grpBox.Controls.Add(label2);
            grpBox.Controls.Add(label3);
            grpBox.Controls.Add(edittext1);
            grpBox.Controls.Add(edittext2);
            grpBox.Controls.Add(edittext3);
            grpBox.Controls.Add(trackbar1);
            grpBox.Controls.Add(trackbar2);
            grpBox.Controls.Add(trackbar3);
        }

        public override void ResetValue() {
            edittext1.Value = edittext2.Value = edittext3.Value = 0;
            trackbar1.Value = trackbar2.Value = trackbar3.Value = 0;
        }

        public override void Execute() {
            float r = (float)edittext1.Value / 100.0F;
            float g = (float)edittext2.Value / 100.0F;
            float b = (float)edittext3.Value / 100.0F;
            float[][] matrixElement =
                                  {new float[]{1, 0, 0, 0, 0},
                                   new float[]{0, 1, 0, 0, 0},
                                   new float[]{0, 0, 1, 0, 0},
                                   new float[]{0, 0, 0, 1, 0},
                                   new float[]{r, g, b, 0, 1}};
            
            ColorMatrix matrix = new ColorMatrix(matrixElement);

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(matrix);

            Bitmap canvas = new Bitmap(b_img.Width, b_img.Height);
            Graphics graph = Graphics.FromImage(canvas);

            graph.DrawImage(b_img,
                new Rectangle(0, 0, b_img.Width, b_img.Height),
                0, 0, b_img.Width, b_img.Height, GraphicsUnit.Pixel,
                attr);

            graph.Dispose();
            a_img = canvas;
        }

        public void Trackbar_Scroll(object sender, EventArgs e) {
            edittext1.Value = trackbar1.Value;
            edittext2.Value = trackbar2.Value;
            edittext3.Value = trackbar3.Value;

            Convert();
        }

        public void NumericUpDown_ValueChanged(object sender, EventArgs e) {
            trackbar1.Value = (int)edittext1.Value;
            trackbar2.Value = (int)edittext2.Value;
            trackbar3.Value = (int)edittext3.Value;

            Convert();
        }
    }
}
