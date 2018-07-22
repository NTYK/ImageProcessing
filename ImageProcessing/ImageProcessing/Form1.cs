using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing {
    public partial class Form1 : Form {
        private bool EXE_FLAG = false;
        private float i_ratioX;
        private float i_ratioY;
        
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Form1_SetupColor();
        }

        private void Form1_SetupColor() {
            string backColor = "#FF252526";
            Color _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            this.BackColor = _color;

            #region //UI Design
            backColor = "#F1F1F1";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            this.CCBt.ForeColor = this.FBt.ForeColor = this.BIPBt.ForeColor = this.HPBt.ForeColor = this.GBt.ForeColor = this.openBt.ForeColor = this.SaveBt.ForeColor = this.ExeBt.ForeColor = _color;
            this.label2.ForeColor = this.label3.ForeColor = this.label4.ForeColor = this.label5.ForeColor = _color;
            this.groupBox1.ForeColor = this.groupBox2.ForeColor = _color;
            backColor = "#3F3F46";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            this.CCBt.BackColor = this.FBt.BackColor = this.BIPBt.BackColor = this.HPBt.BackColor = this.GBt.BackColor = this.openBt.BackColor = this.SaveBt.BackColor = this.ExeBt.BackColor = _color;
            this.panel1.BackColor = this.panel2.BackColor = _color;
            backColor = "#555555";
            _color = System.Drawing.ColorTranslator.FromHtml(backColor);
            this.CCBt.FlatStyle = this.FBt.FlatStyle = this.BIPBt.FlatStyle = this.HPBt.FlatStyle = this.GBt.FlatStyle = this.openBt.FlatStyle = this.SaveBt.FlatStyle = this.ExeBt.FlatStyle = FlatStyle.Flat;
            this.CCBt.FlatAppearance.BorderColor =
                this.FBt.FlatAppearance.BorderColor = this.BIPBt.FlatAppearance.BorderColor =
                this.HPBt.FlatAppearance.BorderColor = this.GBt.FlatAppearance.BorderColor =
                this.openBt.FlatAppearance.BorderColor = this.SaveBt.FlatAppearance.BorderColor = 
                this.ExeBt.FlatAppearance.BorderColor =_color;
            #endregion
        }

    }
}
