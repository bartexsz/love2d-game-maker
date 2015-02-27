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
            ((Resources.Sprite)Resources.resources[id]).origin = new Point((int)numericUpDown1.Value,(int)numericUpDown2.Value);
        }

        private void Spriteeditor_Load(object sender, EventArgs e)
        {
            if (sprites.Count > 0)
            {
                btnSave.Enabled = true;
                btnEdit.Enabled = true;
                button3.Enabled = true;

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

                groupBox1.Enabled = true;

                numericUpDown1.Maximum = sprites[0].Width;
                numericUpDown2.Maximum = sprites[0].Height;
                
                numericUpDown1.Value = ((Resources.Sprite)Resources.resources[id]).origin.X;
                numericUpDown2.Value = ((Resources.Sprite)Resources.resources[id]).origin.Y;
            }
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

                if (sprites.Count > 0)
                {
                    if (spr.Width <= sprites[0].Width && spr.Height <= sprites[0].Height)
                    {
                        PictureBox pb = new PictureBox();
                        sprites.Add(spr);
                        pboxes.Add(pb);
                        pb.Image = spr;
                        TabPage tbpg = new TabPage();
                        tbpg.Text = "frame" + (tabControl1.TabPages.Count + 1).ToString();
                        pb.Parent = tbpg;
                        pb.Dock = DockStyle.Fill;
                        pb.BackColor = Color.FromArgb(144, 212, 242);
                        tbpg.Controls.Add(pb);
                        tabControl1.TabPages.Add(tbpg);

                        if (tabControl1.TabPages.Count > 1)
                        {
                            button2.Enabled = true;
                        }

                        btnEdit.Enabled = true;
                        btnSave.Enabled = true;
                        button3.Enabled = true;
                        groupBox1.Enabled = true;

                        numericUpDown1.Maximum = spr.Width;
                        numericUpDown2.Maximum = spr.Height;
                    }
                    else
                    {
                        System.Media.SystemSounds.Hand.Play();
                        CustomMessageBox.Show("Your sprites must be all of the same maximum size to be loaded!", "Love Game Maker", CustomMessageBox.eDialogButtons.OK, Main.error);
                    }
                }
                else
                {
                    PictureBox pb = new PictureBox();
                    sprites.Add(spr);
                    pboxes.Add(pb);
                    pb.Image = spr;
                    TabPage tbpg = new TabPage();
                    tbpg.Text = "frame" + (tabControl1.TabPages.Count + 1).ToString();
                    pb.Parent = tbpg;
                    pb.Dock = DockStyle.Fill;
                    pb.BackColor = Color.FromArgb(144, 212, 242);
                    tbpg.Controls.Add(pb);
                    tabControl1.TabPages.Add(tbpg);

                    if (tabControl1.TabPages.Count > 1)
                    {
                        button2.Enabled = true;
                    }

                    btnEdit.Enabled = true;
                    btnSave.Enabled = true;
                    button3.Enabled = true;
                    groupBox1.Enabled = true;

                    numericUpDown1.Maximum = spr.Width;
                    numericUpDown2.Maximum = spr.Height;
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

            try
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\temp"))
                {
                    System.IO.Directory.Delete(Application.StartupPath + "\\temp", true);
                }
            }
            catch (Exception ex)
            {
                //
            }

            System.IO.Directory.CreateDirectory(Application.StartupPath+"\\temp");
            sprites[tabControl1.SelectedIndex].Save(Application.StartupPath+"\\temp\\tmpedit.png");
            System.Diagnostics.Process pnt = new System.Diagnostics.Process();
            pnt.StartInfo = new System.Diagnostics.ProcessStartInfo("mspaint",'"'+Application.StartupPath+"\\temp\\tmpedit.png"+'"');

            CustomMessageBox.Show("Edit the Sprite to your liking, press save, and close the program.","Love Game Maker",CustomMessageBox.eDialogButtons.OKCancel,Main.warning);

            pnt.Start();
            pnt.WaitForExit();
            if (new Bitmap(Application.StartupPath + "\\temp\\tmpedit.png").Width <= sprites[0].Width && new Bitmap(Application.StartupPath + "\\temp\\tmpedit.png").Height <= sprites[0].Height)
            {
                sprites[tabControl1.SelectedIndex] = new Bitmap(Application.StartupPath+"\\temp\\tmpedit.png");
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
                CustomMessageBox.Show("Your sprites must be all of the same maximum size to be loaded!","Love Game Maker",CustomMessageBox.eDialogButtons.OK,Main.error);
            }
            tabControl1.TabPages.Clear();
            pboxes.Clear();
            int i = 0;

            foreach (Image spr in sprites)
            {
                PictureBox pb = new PictureBox();
                pboxes.Add(pb);
                pb.Image = spr;
                TabPage tbpg = new TabPage();
                tbpg.Text = "frame" + i.ToString();
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
            this.UseWaitCursor = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sprites.Remove(sprites[tabControl1.SelectedIndex]);
            tabControl1.TabPages.Clear();
            pboxes.Clear();
            int i = 0;

            foreach (Image spr in sprites)
            {
                PictureBox pb = new PictureBox();
                pboxes.Add(pb);
                pb.Image = spr;
                TabPage tbpg = new TabPage();
                tbpg.Text = "frame" + i.ToString();
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

            if (tabControl1.TabPages.Count > tabControl1.SelectedIndex)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }

            if (tabControl1.TabPages.Count <= tabControl1.SelectedIndex + 1)
            {
                button2.Enabled = false;
            }

            if (tabControl1.SelectedIndex > 0)
            {
                button1.Enabled = true;
            }

            if (tabControl1.SelectedIndex >= 0)
            {
                label3.Text = tabControl1.SelectedIndex.ToString();
            }
            else
            {
                label3.Text = "0";
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = (int)(sprites[0].Width / 2);
            numericUpDown2.Value = (int)(sprites[0].Height / 2);
        }
    }
}
