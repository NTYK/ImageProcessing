using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing {
    class Geometric : Process {
        private Label label1;
        private NumericUpDown edittext1;
        private TrackBar trackbar1;
        private Button button1, button2, button3;
        private int STATE = 0;
        private int[] data;

        public Geometric(Image image, PictureBox pictureBox, GroupBox groupBox)
            : base(image, pictureBox, groupBox) {
        }

        public override void ViewControls() {
            #region Label
            label1 = new Label();
            label1.Text = "Angle";
            label1.Location = new Point(10, INTERVAL_Y * 1 - 15);
            label1.Size = new Size(80, 17);
            #endregion

            #region NumericUpDown
            edittext1 = new NumericUpDown();
            edittext1.Increment = 1;
            edittext1.Minimum = -180;
            edittext1.Maximum = 180;
            edittext1.Value = 0;
            edittext1.Location = new Point(125, INTERVAL_Y * 1 - 15);
            edittext1.Size = new Size(60, 24);
            edittext1.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);
            #endregion

            #region TrackBar
            trackbar1 = new TrackBar();
            trackbar1.Minimum = -180;
            trackbar1.Maximum = 180;
            trackbar1.Value = 0;
            trackbar1.Location = new Point(10, INTERVAL_Y * 2 - 30);
            trackbar1.Size = new Size(175, 24);
            trackbar1.TickStyle = TickStyle.None;
            trackbar1.Scroll += new EventHandler(Trackbar_Scroll);
            #endregion

            #region Button
            button1 = new Button();
            button1.Text = "Rotate";
            button1.Location = new Point(10, INTERVAL_Y * 3 - 30);
            button1.Size = new Size(175, 30);
            button1.Click += new EventHandler(button1_Click);

            button2 = new Button();
            button2.Text = "FlipX";
            button2.Location = new Point(10, INTERVAL_Y * 4 - 10);
            button2.Size = new Size(175, 30);
            button2.Click += new EventHandler(button2_Click);

            button3 = new Button();
            button3.Text = "FlipY";
            button3.Location = new Point(10, INTERVAL_Y * 5 - 10);
            button3.Size = new Size(175, 30);
            button3.Click += new EventHandler(button3_Click);
            
            string backColor = "#F1F1F1";
            Color _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.ForeColor = button2.ForeColor = button3.ForeColor = _color;
            backColor = "#3F3F46";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.BackColor = button2.BackColor = button3.BackColor = _color;
            backColor = "#555555";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.FlatStyle = button2.FlatStyle = button3.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = button2.FlatAppearance.BorderColor = button3.FlatAppearance.BorderColor = _color;
            #endregion

            grpBox.Controls.Add(label1);
            grpBox.Controls.Add(edittext1);
            grpBox.Controls.Add(button1);
            grpBox.Controls.Add(button2);
            grpBox.Controls.Add(button3);
            grpBox.Controls.Add(trackbar1);
        }

        public override void ResetValue() {
            ResetGrp();
            ViewControls();
        }

        public override void Execute() {
            double ratio;
            byte[,] img = LoadByteImage();
            Bitmap bitmap = new Bitmap(b_img);
            int h = bitmap.Height;
            int w = bitmap.Width;
            byte[,] dst = new byte[w, h];
            Bitmap bmp = new Bitmap(b_img);

            switch (STATE) {
                case 0:
                    #region Rotate
                    Bitmap bmp2 = new Bitmap(b_img.Width, b_img.Height);
                    Graphics g = Graphics.FromImage(bmp2);
                    g.Clear(Color.Black);

                    g.TranslateTransform(-(w / 2), -(h / 2));
                    g.RotateTransform(trackbar1.Value, System.Drawing.Drawing2D.MatrixOrder.Append);
                    g.TranslateTransform(w / 2, h / 2, System.Drawing.Drawing2D.MatrixOrder.Append);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    g.DrawImageUnscaled(bmp, 0, 0);
                    g.Dispose();
                    a_img = bmp2;
                    break;
                    #endregion
                case 1:
                    #region FlipX
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    a_img = bmp;
                    break;
                    #endregion
                case 2:
                    #region FlipY
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    a_img = bmp;
                    break;
                    #endregion
                default:
                    return;
            }
        }

        public byte[,] LoadByteImage() {
            Bitmap bitmap = new Bitmap(b_img);
            byte[,] data = new byte[bitmap.Width, bitmap.Height];

            for (int y = 0; y < bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    int r = bitmap.GetPixel(x, y).R;
                    int g = bitmap.GetPixel(x, y).G;
                    int b = bitmap.GetPixel(x, y).B;
                    byte val = (byte)( (r+g+b)/ 3);
                    data[x, y] = val;
                }
            }
            return data;
        }

        public void Trackbar_Scroll(object sender, EventArgs e) {
            edittext1.Value = trackbar1.Value;
        }

        public void NumericUpDown_ValueChanged(object sender, EventArgs e) {
            trackbar1.Value = (int)edittext1.Value;
        }


        public void button1_Click(object sender, EventArgs e) {
            STATE = 0;
            Convert();
        }

        public void button2_Click(object sender, EventArgs e) {
            STATE = 1;
            Convert();
        }

        public void button3_Click(object sender, EventArgs e) {
            STATE = 2;
            Convert();
        }
    }
}
