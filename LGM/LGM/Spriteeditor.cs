using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGM
{
    public partial class Spriteeditor : Form
    {
        public Spriteeditor()
        {
            InitializeComponent();
        }

        private void Spriteeditor_Load(object sender, EventArgs e)
        {
            //
            pictureBox1.BackColor = Color.FromArgb(144, 212, 242);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
