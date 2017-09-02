using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hal
{
    public partial class Editor : Form
    {
        public int HorizontalFormWeight = 16;
        public int VerticalFormWeight = 38;
        private string _file = "";

        public Editor() {
            InitializeComponent();

            this.Resize += Editor_Resize;
            this.FormClosing += Editor_FormClosing;
            this.txtText.KeyDown += KeyDown;
        }

        void Editor_FormClosing(object sender, FormClosingEventArgs e) {
            System.IO.File.WriteAllLines(_file, txtText.Lines.ToArray());
            e.Cancel = true;
            this.Visible = false;
        }

        void Editor_Resize(object sender, EventArgs e) {
            int width = this.Width - 24 - HorizontalFormWeight;
            int height = this.Height - 24 - VerticalFormWeight;

            txtText.Size = new Size(width, height);
        }

        public void LoadCode(string filepath, string[] lines) {
            _file = filepath;
            this.txtText.Text = "";
            foreach (string line in lines) {
                this.txtText.Text += line + "\r\n";
            }
        }
        public void KeyDown(object sender, KeyEventArgs e) {
            //Program.Write(e.KeyCode.ToString());
        }
    }
}












