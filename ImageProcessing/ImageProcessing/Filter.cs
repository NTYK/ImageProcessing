using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing {
    class Filter : Process {
        private Button button1, button2, button3, button4, button5;
        private int STATE = 0;

        public Filter(Image image, PictureBox pictureBox, GroupBox groupBox) : base(image, pictureBox, groupBox) { }

        public override void ViewControls() {
            #region Button
            button1 = new Button();
            button1.Text = "Mean Filter";
            button1.Location = new Point(10, INTERVAL_Y * 1 - 15);
            button1.Size = new Size(175, 30);
            button1.Click += new EventHandler(button1_Click);

            button2 = new Button();
            button2.Text = "Gaussian Filter";
            button2.Location = new Point(10, INTERVAL_Y * 2 - 15);
            button2.Size = new Size(175, 30);
            button2.Click += new EventHandler(button2_Click);

            button3 = new Button();
            button3.Text = "Median Filter";
            button3.Location = new Point(10, INTERVAL_Y * 3 - 15);
            button3.Size = new Size(175, 30);
            button3.Click += new EventHandler(button3_Click);

            button4 = new Button();
            button4.Text = "Sobel Filter";
            button4.Location = new Point(10, INTERVAL_Y * 4 - 15);
            button4.Size = new Size(175, 30);
            button4.Click += new EventHandler(button4_Click);

            button5 = new Button();
            button5.Text = "Emboss Filter";
            button5.Location = new Point(10, INTERVAL_Y * 5 - 15);
            button5.Size = new Size(175, 30);
            button5.Click += new EventHandler(button5_Click);

            string backColor = "#F1F1F1";
            Color _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.ForeColor = button2.ForeColor = button3.ForeColor = button4.ForeColor = button5.ForeColor = _color;
            backColor = "#3F3F46";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.BackColor = button2.BackColor = button3.BackColor = button4.BackColor = button5.BackColor = _color;
            backColor = "#555555";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            button1.FlatStyle = button2.FlatStyle = button3.FlatStyle = button4.FlatStyle = button5.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor =
                button2.FlatAppearance.BorderColor = button3.FlatAppearance.BorderColor =
                button4.FlatAppearance.BorderColor = button5.FlatAppearance.BorderColor = _color;
            #endregion

            grpBox.Controls.Add(button1);
            grpBox.Controls.Add(button2);
            grpBox.Controls.Add(button3);
            grpBox.Controls.Add(button4);
            grpBox.Controls.Add(button5);
        }

        public override void ResetValue() {
        }

        public override void Execute() {
            double[,] kernel;
            byte[,] img2;
            byte[,] img = LoadImageGray();
            const int kernelSize = 3;
            switch (STATE) {
                case 0:
                    #region MeanFilter
                    kernel = new double[kernelSize, kernelSize]{
                                {1/9.0,1/9.0,1/9.0},
                                {1/9.0,1/9.0,1/9.0},
                                {1/9.0,1/9.0,1/9.0}};
                    img2 = MeanFliter(img, kernel);
                    break;
                    #endregion
                case 1:
                    #region GaussianFilter
                    kernel = new double[kernelSize, kernelSize]{
                                {1/16.0, 1/8.0, 1/16.0},
                                {1/8.0,  1/4.0, 1/8.0},
                                {1/16.0, 1/8.0, 1/16.0}};
                    img2 = GausFliter(img, kernel);
                    break;
                    #endregion
                case 2:
                    #region MedianFilter
                    kernel = new double[kernelSize, kernelSize]{
                                {1.0/9.0,1.0/9.0,1.0/9.0},
                                {1.0/9.0,1.0/9.0,1.0/9.0},
                                {1.0/9.0,1.0/9.0,1.0/9.0}};
                    img2 = MedianFliter(img, kernel);
                    break;
                    #endregion
                case 3:
                    #region SobelFilter
                    kernel = new double[kernelSize, kernelSize]{
                                {-1.0,-2.0,-2.0},
                                {0.0,0.0,0.0},
                                {1.0,2.0,1.0}};
                    img2 = SobelFliter(img, kernel);
                    break;
                    #endregion
                case 4:
                    #region EmbossFilter
                    kernel = new double[kernelSize, kernelSize]{
                                {-2.0, -1.0, 0.0},
                                {-1.0,  1.0, 1.0},
                                { 0.0,  1.0, 2.0}};
                    img2 = EmbossFliter(img, kernel);
                    break;
                    #endregion

                default:
                    return;
            }
            ConvertImage(img2);
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

        public void button4_Click(object sender, EventArgs e) {
            STATE = 3;
            Convert();
        }

        public void button5_Click(object sender, EventArgs e) {
            STATE = 4;
            Convert();
        }

        public byte[,] MeanFliter(byte[,] src, double[,] kernel) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int kernelSize = kernel.GetLength(0);
            byte[,] dst = new byte[w, h];

            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    double sum = 0;
                    for (int k = -kernelSize / 2; k <= kernelSize / 2; k++) {
                        for (int n = -kernelSize / 2; n <= kernelSize / 2; n++) {
                            if (x + n >= 0 && x + n < w && y + k >= 0 && y + k < h) {
                                sum += src[x + n, y + k] * kernel[n + kernelSize / 2, k + kernelSize / 2];
                            }
                        }
                    }

                    dst[x, y] = DoubleToByte(sum);
                }
            }
            return dst;
        }

        public byte[,] GausFliter(byte[,] src, double[,] kernel) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int kernelSize = kernel.GetLength(0);
            byte[,] dst = new byte[w, h];

            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    double sum = 0;
                    for (int k = -kernelSize / 2; k <= kernelSize / 2; k++) {
                        for (int n = -kernelSize / 2; n <= kernelSize / 2; n++) {
                            if (x + n >= 0 && x + n < w && y + k >= 0 && y + k < h) {
                                sum += src[x + n, y + k] * kernel[n + kernelSize / 2, k + kernelSize / 2];
                            }
                        }
                    }

                    dst[x, y] = DoubleToByte(sum);
                }
            }
            return dst;
        }

        public byte[,] MedianFliter(byte[,] src, double[,] kernel) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int kernelSize = kernel.GetLength(0);
            byte[,] dst = new byte[w, h];

            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    double sum = 0;
                    for (int k = -kernelSize / 2; k <= kernelSize / 2; k++) {
                        for (int n = -kernelSize / 2; n <= kernelSize / 2; n++) {
                            if (x + n >= 0 && x + n < w && y + k >= 0 && y + k < h) {
                                sum += src[x + n, y + k] * kernel[n + kernelSize / 2, k + kernelSize / 2];
                            }
                        }
                    }

                    dst[x, y] = DoubleToByte(sum);
                }
            }
            return dst;
        }

        public byte[,] SobelFliter(byte[,] src, double[,] kernel) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int kernelSize = kernel.GetLength(0);
            byte[,] dst = new byte[w, h];

            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    double sum = 0;
                    for (int k = -kernelSize / 2; k <= kernelSize / 2; k++) {
                        for (int n = -kernelSize / 2; n <= kernelSize / 2; n++) {
                            if (x + n >= 0 && x + n < w && y + k >= 0 && y + k < h) {
                                sum += src[x + n, y + k] * kernel[n + kernelSize / 2, k + kernelSize / 2];
                            }
                        }
                    }

                    dst[x, y] = DoubleToByte(sum);
                }
            }
            return dst;
        }

        public byte[,] EmbossFliter(byte[,] src, double[,] kernel) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int kernelSize = kernel.GetLength(0);
            byte[,] dst = new byte[w, h];

            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    double sum = 0;
                    for (int k = -kernelSize / 2; k <= kernelSize / 2; k++) {
                        for (int n = -kernelSize / 2; n <= kernelSize / 2; n++) {
                            if (x + n >= 0 && x + n < w && y + k >= 0 && y + k < h) {
                                sum += src[x + n, y + k] * kernel[n + kernelSize / 2, k + kernelSize / 2];
                            }
                        }
                    }

                    dst[x, y] = DoubleToByte(sum);
                }
            }
            return dst;
        }
        
        public byte[,] LoadImageGray() {
            Bitmap img = new Bitmap(b_img);
            int w = img.Width;
            int h = img.Height;
            byte[,] dst = new byte[w, h];

            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    dst[x, y] = (byte)((img.GetPixel(x, y).R + img.GetPixel(x, y).B + img.GetPixel(x, y).G) / 3);
                }
            }
            return dst;
        }

        public byte DoubleToByte(double num) {
            if (num > 255.0) return 255;
            else if (num < 0) return 0;
            else return (byte)num;
        }

        public void ConvertImage(byte[,] src) {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            Bitmap img = new Bitmap(w, h);
            for (int y = 0; y < h; y++) {
                for (int x = 0; x < w; x++) {
                    img.SetPixel(x, y, Color.FromArgb(src[x, y], src[x, y], src[x, y]));
                }
            }
            a_img = img;
        }
    }
}
