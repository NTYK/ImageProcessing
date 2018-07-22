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
    class HistogramProcess : Process {
        private Chart chart;
        private Label label1, label2;
        private NumericUpDown edittext1, edittext2;
        private TrackBar trackbar1, trackbar2;
        private Button button1, button2;
        private int STATE = 0;
        private int[] data;

        public HistogramProcess(Image image, PictureBox pictureBox, GroupBox groupBox)
            : base(image, pictureBox, groupBox) {
        }

        public override void ViewControls() {
            #region Chart
            chart = new Chart();
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
            Series seriesColumn = new Series();
            ChartArea area1 = new ChartArea();

            seriesColumn.ChartType = SeriesChartType.Column;

            #region //データの生成
            byte[,] bImage = LoadByteImage();
            data = new int[256];
            get_hist(bImage, data, bImage.GetLength(0), bImage.GetLength(1));
            #endregion

            area1.AxisX.LabelStyle.Enabled = false;
            area1.AxisY.LabelStyle.Enabled = false;
            area1.AxisX2.Enabled = AxisEnabled.False;
            area1.AxisY.Enabled = AxisEnabled.False;
            area1.AxisY2.Enabled = AxisEnabled.False;
            area1.AxisX.Interval = 51;
            area1.BackColor = chart.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D30");
            area1.AxisX.MajorGrid.LineColor = area1.AxisY.MajorGrid.LineColor = System.Drawing.ColorTranslator.FromHtml("#434346");

            for (int cnt = 0; cnt < data.Length; cnt++) {
                seriesColumn.Points.AddXY(cnt, data[cnt]);
            }

            chart.ChartAreas.Add(area1);
            chart.Series.Add(seriesColumn);

            chart.Location = new Point(10, INTERVAL_Y * 1 - 20);
            chart.Size = new Size(180, 60);
            #endregion

            #region Label
            label1 = new Label();
            label1.Text = "LEFT";
            label1.Location = new Point(10, INTERVAL_Y * 3 - 35);
            label1.Size = new Size(17, 17);

            label2 = new Label();
            label2.Text = "RIGHT";
            label2.Location = new Point(10, INTERVAL_Y * 4 - 25);
            label2.Size = new Size(17, 17);
            #endregion

            #region NumericUpDown
            edittext1 = new NumericUpDown();
            edittext1.Increment = 1;
            edittext1.Minimum = 0;
            edittext1.Maximum = 255;
            edittext1.Value = 0;
            edittext1.Location = new Point(125, INTERVAL_Y * 3 - 35);
            edittext1.Size = new Size(60, 24);
            edittext1.ValueChanged += new EventHandler(leftNumericUpDown_ValueChanged);

            edittext2 = new NumericUpDown();
            edittext2.Increment = 1;
            edittext2.Minimum = 0;
            edittext2.Maximum = 255;
            edittext2.Value = 255;
            edittext2.Location = new Point(125, INTERVAL_Y * 4 - 25);
            edittext2.Size = new Size(60, 24);
            edittext2.ValueChanged += new EventHandler(rightNumericUpDown_ValueChanged);
            #endregion

            #region TrackBar
            trackbar1 = new TrackBar();
            trackbar1.Minimum = 0;
            trackbar1.Maximum = 255;
            trackbar1.Value = 0;
            trackbar1.Location = new Point(10, INTERVAL_Y * 4 - 50);
            trackbar1.Size = new Size(175, 24);
            trackbar1.TickStyle = TickStyle.None;
            trackbar1.Scroll += new EventHandler(leftTrackbar_Scroll);

            trackbar2 = new TrackBar();
            trackbar2.Minimum = 0;
            trackbar2.Maximum = 255;
            trackbar2.Value = 255;
            trackbar2.Location = new Point(10, INTERVAL_Y * 5 - 40);
            trackbar2.Size = new Size(175, 24);
            trackbar2.TickStyle = TickStyle.None;
            trackbar2.Scroll += new EventHandler(rightTrackbar_Scroll);
            #endregion

            #region Button
            button1 = new Button();
            button1.Text = "Enlarge";
            button1.Location = new Point(10, INTERVAL_Y * 5 - 10);
            button1.Size = new Size(175, 30);
            button1.Click += new EventHandler(button1_Click);

            button2 = new Button();
            button2.Text = "Flattening";
            button2.Location = new Point(10, INTERVAL_Y * 6 - 10);
            button2.Size = new Size(175, 30);
            button2.Click += new EventHandler(button2_Click);
            
            string backColor = "#F1F1F1";
            Color _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.ForeColor = button2.ForeColor = _color;
            backColor = "#3F3F46";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.BackColor = button2.BackColor = _color;
            backColor = "#555555";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.FlatStyle = button2.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = button2.FlatAppearance.BorderColor = _color;
            #endregion

            grpBox.Controls.Add(chart);
            grpBox.Controls.Add(label1);
            grpBox.Controls.Add(label2);
            grpBox.Controls.Add(edittext1);
            grpBox.Controls.Add(edittext2);
            grpBox.Controls.Add(button1);
            grpBox.Controls.Add(button2);
            grpBox.Controls.Add(trackbar1);
            grpBox.Controls.Add(trackbar2);
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
            byte[,] dst = new byte[w, h];;

            switch (STATE) {
                case 0:
                    #region Enlarge
                    int left = (int)edittext1.Value;
                    int right = (int)edittext2.Value;
                    int diff = right - left;
                    ratio = 255.0f / (double)diff;
                    for (int y = 0; y < h; y++) {
                        for (int x = 0; x < w; x++) {
                            if (left <= (int)img[x, y] && (int)img[x, y] <= right) {
                                dst[x, y] = (byte)((int)img[x, y] * ratio);
                            }
                            else {
                                dst[x, y] = (byte)0;
                            }
                        }
                    }

                    break;
                    #endregion
                case 1:
                    #region Flat
                    int s = w * h;
                    int imax = 0;
                    for (int i = 0; i < 256; i++) {
                        if (imax < data[i]) {
                            imax = i;
                        }
                    }
                    
                    for (int y = 0; y < h; y++) {
                        for (int x = 0; x < w; x++) {
                            int sum = 0;
                            for (int cnt = 0; cnt < (int)img[x, y]; cnt++) {
                                sum += data[cnt];
                            }
                            ratio = (double)imax / (double)s;
                            double num = (double)sum * ratio;
                            dst[x, y] = DoubleToByte(num);
                        }
                    }
                    break;
                    #endregion
                default:
                    return;
            }
            ConvertImage(dst);
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

        static public void get_hist(byte[,] data, int[] hist, int X, int Y) {
            int h;

            for (int k = 0; k < 256; k++)
                hist[k] = 0;
            for (int y = 0; y < Y; y++) {
                for (int x = 0; x < X; x++) {
                    h = (int)data[x, y];
                    hist[h]++;
                }
            }
        }

        public void leftTrackbar_Scroll(object sender, EventArgs e) {
            if ((int)trackbar1.Value < (int)trackbar2.Value) {
                edittext1.Value = (int)trackbar1.Value;
            }else {
                trackbar1.Value -= 1;
                edittext1.Value = (int)trackbar1.Value;
            }
        }

        public void rightTrackbar_Scroll(object sender, EventArgs e) {
            if ((int)trackbar1.Value < (int)trackbar2.Value) {
                edittext2.Value = (int)trackbar2.Value;
            }else {
                trackbar2.Value += 1;
                edittext2.Value = (int)trackbar2.Value;
            }
        }

        public void leftNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if ((int)edittext1.Value < (int)edittext2.Value) {
                trackbar1.Value = (int)edittext1.Value;
            }else {
                edittext1.Value -= 1;
                trackbar1.Value = (int)edittext1.Value;
            }
        }

        public void rightNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if ((int)edittext1.Value < (int)edittext2.Value) {
                trackbar2.Value = (int)edittext2.Value;
            }else {
                edittext2.Value += 1;
                trackbar2.Value = (int)edittext2.Value;
            }
        }

        public void button1_Click(object sender, EventArgs e) {
            STATE = 0;
            Convert();
        }

        public void button2_Click(object sender, EventArgs e) {
            STATE = 1;
            Convert();
        }
        
        public byte DoubleToByte(double num) {
            if (num > 255.0) return 255;
            else if (num < 0) return 0;
            else return (byte)num;
        }

        public void ConvertImage(byte[,] src) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            Bitmap result = new Bitmap(w, h);
            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    result.SetPixel(x, y, Color.FromArgb(src[x, y], src[x, y], src[x, y]));
                }
            }
            a_img = result;
        }
    }
}
