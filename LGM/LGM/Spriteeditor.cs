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
            this.FormClosing += Spriteeditor_FormClosing;
        }

        void Spriteeditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Resources.resources[id].isbeingedited = false;
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.Title = "Load a Sprite...";
            ofd.Filter = "Portable Network Graphic|*.png|JPEG Image|*.jpg*.jpeg";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sprite = new Bitmap(ofd.FileName);
                pictureBox1.Image = sprite;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                sprite = pictureBox1.Image;
            }
            name = textBox1.Text;
            Resources.resources[id].name = name;
            Resources.Sprite spr = (Resources.Sprite)Resources.resources[id];
            spr.sprite = sprite;
            Main.UpdateTreeView(Main.resourcelistpublic);
            this.Close();
        }
    }
}
