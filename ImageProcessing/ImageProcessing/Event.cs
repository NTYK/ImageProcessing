using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessing {
    public partial class Form1 : Form {
        private Process process;

        private void OpenBt_Click(object sender, EventArgs e){
            openFD.ShowDialog(this);
        }

        private void SaveBt_Click(object sender, EventArgs e) {
            if (EXE_FLAG) {
                const string NEW_FILE_NAME = "新規イメージファイル";
                saveFD.FileName = NEW_FILE_NAME;
                saveFD.ShowDialog(this);
            }
        }

        private void CCBt_Click(object sender, EventArgs e){
            process = new ColorConversion(picBox1.Image, picBox2, groupBox2);
            process.GetOutput();
        }

        private void FBt_Click(object sender, EventArgs e) {
            process = new Filter(picBox1.Image, picBox2, groupBox2);
            process.GetOutput();
        }

        private void BIPBt_Click(object sender, EventArgs e) {
            process = new BinaryImageProcess(picBox1.Image, picBox2, groupBox2);
            process.GetOutput();
        }

        private void HPBt_Click(object sender, EventArgs e) {
            process = new HistogramProcess(picBox1.Image, picBox2, groupBox2);
            process.GetOutput();
        }

        private void GBt_Click(object sender, EventArgs e) {
            process = new Geometric(picBox1.Image, picBox2, groupBox2);
            process.GetOutput();
        }

        private void ExeBt_Click(object sender, EventArgs e) {
            if (picBox2.Image != null) {
                EXE_FLAG = true;
                picBox1.Image = picBox2.Image;
                process.ResetBitmap(picBox1.Image);
                process.ResetValue();
                picBox2.Image = null;
            }
        }

        private void openFD_FileOk(object sender, CancelEventArgs e) {
            string openFilePath = openFD.FileName;
            int imageWidth, imageHeight;
            picBox2.Image = null;
            EXE_FLAG = false;
            try {
                Image img = Image.FromFile(openFilePath);
                imageWidth = img.Width;
                imageHeight = img.Height;
                i_ratioX = i_ratioY = 1;
                bool judge_width = img.Width > picBox1.Width;
                bool judge_heigth = img.Height > picBox1.Height;
                if (judge_width || judge_heigth) {
                    if (!judge_heigth) {
                        i_ratioX = img.Width / picBox1.Width;
                        imageWidth = picBox1.Width;
                    }
                    else if (!judge_width) {
                        i_ratioY = img.Height / picBox1.Height;
                        imageHeight = picBox1.Height;
                    }
                    else {
                        if ((float)img.Width / (float)picBox1.Width > (float)img.Height / (float)picBox1.Height) {
                            i_ratioX = i_ratioY = (float)img.Width / (float)picBox1.Width;
                            imageWidth = picBox1.Width;
                            imageHeight = (int)(img.Height / i_ratioY);
                        }
                        else if ((float)img.Width / (float)picBox1.Width < (float)img.Height / (float)picBox1.Height) {
                            i_ratioX = i_ratioY = (float)img.Height / (float)picBox1.Height;
                            imageWidth = (int)(img.Width / i_ratioX);
                            imageHeight = picBox1.Height;
                        }
                        else {
                            i_ratioX = i_ratioY = (float)img.Height / (float)picBox1.Height;
                            imageWidth = picBox1.Width;
                            imageHeight = picBox1.Height;
                        }
                    }
                }

                Bitmap canvas = new Bitmap(imageWidth, imageHeight);
                Graphics g = Graphics.FromImage(canvas);
                g.DrawImage(img, 0, 0, imageWidth, imageHeight);
                img.Dispose();
                g.Dispose();
                picBox1.Image = canvas;
                picBox1.Visible = true;
                picBox2.Image = null;

















                /*
                Bitmap canvas = new Bitmap(picBox1.Width, picBox1.Height);
                Graphics g = Graphics.FromImage(canvas);
                Image img = Image.FromFile(openFilePath);
                imageWidth = img.Width;
                imageHeight = img.Height;
                i_ratioX = i_ratioY = 1;
                bool judge_width = img.Width > picBox1.Width;
                bool judge_heigth = img.Height > picBox1.Height;
                if (judge_width || judge_heigth) {
                    if (!judge_heigth) {
                        i_ratioX = img.Width / picBox1.Width;
                        imageWidth = picBox1.Width;
                    }else if (!judge_width) {
                        i_ratioY = img.Height / picBox1.Height;
                        imageHeight = picBox1.Height;
                    }else {
                        if(img.Width / picBox1.Width > img.Height / picBox1.Height) {
                            i_ratioX = i_ratioY = img.Width / picBox1.Width;
                            imageWidth = picBox1.Width;
                            imageHeight = (int)(picBox1.Height / i_ratioY);
                        }else if(img.Width / picBox1.Width < img.Height / picBox1.Height){                   
                            i_ratioX = i_ratioY = img.Height / picBox1.Height;
                            imageWidth = (int)(picBox1.Width / i_ratioX);
                            imageHeight = picBox1.Height;
                        }else {
                            i_ratioX = i_ratioY = img.Height / picBox1.Height;
                            imageWidth = picBox1.Width;
                            imageHeight = picBox1.Height;
                        }
                    }
                }

                g.DrawImage(
                    img,
                    picBox1.Width / 2 - imageWidth / 2,
                    picBox1.Height / 2 - imageHeight / 2,
                    imageWidth,
                    imageHeight);
                img.Dispose();
                g.Dispose();
                picBox1.Image = canvas;
                picBox1.Visible = true;
                picBox2.Image = null;*/
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "ファイルオープン", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            while (groupBox2.Controls.Count > 0) {
                groupBox2.Controls.Remove(groupBox2.Controls[0]);
            }
        }

        private void saveFD_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            string saveFilePath = saveFD.FileName;
            try {
                Bitmap canvas = new Bitmap(picBox1.Width * (int)i_ratioX, picBox1.Height * (int)i_ratioY);
                Graphics g = Graphics.FromImage(canvas);
                g.DrawImage(picBox1.Image, 0, 0, picBox1.Width * (int)i_ratioX, picBox1.Height * (int)i_ratioY);
                g.Dispose();
                canvas.Save(saveFilePath);
                canvas.Dispose();
            }catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "名前を付けて保存", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
