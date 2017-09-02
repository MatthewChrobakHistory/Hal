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
    public partial class ACP : Form
    {
        public ACP() {
            InitializeComponent();

            cmdRun.Click += cmdRun_Click;
            this.txtCommand.Focus();
        }

        void cmdRun_Click(object sender, EventArgs e) {
            Program.InterpretCommand(txtCommand.Text);
            txtCommand.Text = "";
        }
    }
}

