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
        public List<Image> sprites = new List<Image>();
        private List<PictureBox> pboxes = new List<PictureBox>();

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
            if (sprites.Count > 0)
            {
                int i = 0;
                foreach (Image spr in sprites)
                {
                    PictureBox pb = new PictureBox();
                    pboxes.Add(pb);
                    pb.Image = spr;
                    TabPage tbpg = new TabPage();
                    tbpg.Text = "frame"+i.ToString();
                    tabControl1.TabPages.Add(tbpg);
                    pb.Parent = tbpg;
                    pb.Dock = DockStyle.Fill;
                    pb.BackColor = Color.FromArgb(144, 212, 242);
                    tbpg.Controls.Add(pb);
                    pboxes.Add(pb);
                    i++;

                    if (tabControl1.TabPages.Count > 1)
                    {
                        button2.Enabled = true;
                    }
                }

            }
            //framepb1.BackColor = Color.FromArgb(144, 212, 242);
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
            ofd.Title = "Load a Frame...";
            ofd.Filter = "Portable Network Graphic|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap spr = new Bitmap(ofd.FileName);

                PictureBox pb = new PictureBox();
                sprites.Add(spr);
                pboxes.Add(pb);
                pb.Image = spr;
                TabPage tbpg = new TabPage();
                tbpg.Text = "frame"+(tabControl1.TabPages.Count+1).ToString();
                pb.Parent = tbpg;
                pb.Dock = DockStyle.Fill;
                pb.BackColor = Color.FromArgb(144, 212, 242);
                tbpg.Controls.Add(pb);
                tabControl1.TabPages.Add(tbpg);

                if (tabControl1.TabPages.Count > 1)
                {
                    button2.Enabled = true;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            Resources.resources[id].name = name;
            Resources.Sprite spr = (Resources.Sprite)Resources.resources[id];
            spr.sprites = sprites;
            Main.UpdateTreeView(Main.resourcelistpublic);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > tabControl1.SelectedIndex)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }

            if (tabControl1.TabPages.Count <= tabControl1.SelectedIndex+1)
            {
                button2.Enabled = false;
            }

            if (tabControl1.SelectedIndex > 0)
            {
                button1.Enabled = true;
            }

            label3.Text = tabControl1.SelectedIndex.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
            }

            if (tabControl1.TabPages.Count > tabControl1.SelectedIndex)
            {
                button2.Enabled = true;
            }

            if (tabControl1.SelectedIndex == 0)
            {
                button1.Enabled = false;
            }

            label3.Text = tabControl1.SelectedIndex.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Title = "Save this Sprite...";
            sfd.Filter = "Portable Network Graphic|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int i = 0;
                foreach (Image spr in sprites)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(sfd.FileName);
                    spr.Save(fi.Directory+"\\"+fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length) + i.ToString() + fi.Extension);
                    i++;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;

            if (System.IO.Directory.Exists(Application.StartupPath+"\\temp"))
            {
                System.IO.Directory.Delete(Application.StartupPath+"\\temp",true);
            }

            System.IO.Directory.CreateDirectory(Application.StartupPath+"\\temp");
            sprites[tabControl1.SelectedIndex].Save(Application.StartupPath+"\\temp\\tmpedit.png");
            System.Diagnostics.Process pnt = new System.Diagnostics.Process();
            pnt.StartInfo = new System.Diagnostics.ProcessStartInfo("mspaint",'"'+Application.StartupPath+"\\temp\\tmpedit.png"+'"');

            CustomMessageBox.Show("Edit the Sprite to your liking, press save, and close the program.","Love Game Maker",CustomMessageBox.eDialogButtons.OKCancel,Main.warning);

            pnt.Start();
            pnt.WaitForExit();
            sprites[tabControl1.SelectedIndex] = new Bitmap(Application.StartupPath+"\\temp\\tmpedit.png");
            this.UseWaitCursor = false;
        }
    }
}
