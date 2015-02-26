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
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
            this.AcceptButton = button2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void options_Load(object sender, EventArgs e)
        {
            textBox1.Text = settings.love2dpath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Saves the settings and closes the options window.
            if (settings.IsLove2DFolder(textBox1.Text))
            {
                settings.love2dpath = textBox1.Text;
                settings.SaveSettings();
                this.Close();
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
                CustomMessageBox.Show("The given path does not contain the required LÖVE 2D files.", "Love Game Maker", CustomMessageBox.eDialogButtons.OK, Main.error);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if (fld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = fld.SelectedPath;
            }
        }
    }
}
