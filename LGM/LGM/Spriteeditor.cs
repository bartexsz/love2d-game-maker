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
        public string name = "";
        public int id;
        public Image sprite = null;

        public Spriteeditor()
        {
            InitializeComponent();
        }

        private void Spriteeditor_Load(object sender, EventArgs e)
        {
            if (sprite != null)
            {
                pictureBox1.Image = sprite;
            }
            pictureBox1.BackColor = Color.FromArgb(144, 212, 242);
            textBox1.Text = name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
    }
}
