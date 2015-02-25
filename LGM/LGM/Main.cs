using System;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using FastColoredTextBoxNS;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LGM
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;
        public static string projectname = null;
        public static bool issaved = true;
        public static bool ontreeview = false;
        //public static ImageList imglist;
        TreeNode Sprites;
        TreeNode Objects;
        TreeNode Backgrounds;
        TreeNode Sounds;
        TreeNode Rooms;
        TreeNode Scripts;

        private Image warning = Properties.Resources.warning1;
        private Image error = Properties.Resources.error1;

        public Main()
        {
            //Initialize the main component
            InitializeComponent();

            //Add Events
            this.FormClosing += Main_Closing;
            toolStrip.Renderer = new MyToolStripSystemRenderer();
            resourcelist.MouseMove += treeView1_MouseMove;
            resourcelist.MouseLeave += treeView1_MouseLeave;
            MDIClientSupport.SetBevel(this,false);
            UpdateTitle();

            //Define the TreeNode variables
            Sprites = this.resourcelist.Nodes[0];
            Objects = this.resourcelist.Nodes[1];
            Backgrounds = this.resourcelist.Nodes[2];
            Sounds = this.resourcelist.Nodes[3];
            Rooms = this.resourcelist.Nodes[4];
            Scripts = this.resourcelist.Nodes[5];

            //Define all the Resource variables
            Resources.DefineResourceArrays();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = Color.FromArgb(144, 212, 242);
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            //TEMPORARY: Add registry key to disable dpi scaling for this program. Will be handled by the installer in the final version.
            /*if (System.IO.File.Exists(Application.StartupPath + "\\changedpi.bat") && System.IO.File.Exists(Application.StartupPath + "\\dontdeleteme.txt") && MessageBox.Show("The application has detected this is your first time running Love game Maker. The program will now write a registry value to prevent im-proper DPI scaling of the program (making everything look bad/out of place.) Do you wish to proceed? (Things may look seriously messed up through-out the program if you don't!) This will be done automatically by the installer in the final release.","Love Game Maker",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string blankchngdpi = System.IO.File.ReadAllText(Application.StartupPath + "\\changedpi.bat");
                string path = Application.StartupPath+"\\LGM.exe";
                string chngdpitxt = blankchngdpi.Substring(0, 86) + path;
                chngdpitxt += blankchngdpi.Substring(86);
                System.IO.File.WriteAllText(Application.StartupPath+"\\changedpi.bat",chngdpitxt);
                ProcessStartInfo chngdpi = new ProcessStartInfo(Application.StartupPath+"\\changedpi.bat");
                chngdpi.CreateNoWindow = true;
                Process chngdpiprc = Process.Start(chngdpi);
                chngdpiprc.WaitForExit();
                System.IO.File.WriteAllText(Application.StartupPath+"\\changedpi.bat",blankchngdpi);
                System.IO.File.Delete(Application.StartupPath+"\\dontdeleteme.txt");
                Process.Start(Application.StartupPath+"\\LGM.exe");
                Application.Exit();
            }*/
            
        }

        private void AddSprite()
        {
            //Adds a sprite to the resource list
            if (resourcelist.GetNodeCount(true) > 0 && resourcelist.Nodes[0] != null)
            {
                Resources.resourcenames[0, Resources.resourcetypecnt[0]] = "Sprite" + Resources.resourcetypecnt[0].ToString();
                TreeNode newsprite = resourcelist.Nodes[0].Nodes.Add(Resources.resourcenames[0,Resources.resourcetypecnt[0]]);
                //MessageBox.Show(resourcelist.Nodes[0].Nodes[Resources.resourcetypecnt[0]].ToString());
                //MessageBox.Show(Resources.resourcenames[0,Resources.resourcetypecnt[0]]);
                /*string yourChildNode;
                yourChildNode = "Sprite" + whatever.ToString();
                TreeNode ok = resourcelist.Nodes[0].Nodes.Add(yourChildNode);
                //whatever++;
                MessageBox.Show(resourcelist.Nodes[0].Nodes[whatever-1].ToString());*/
                resourcelist.ExpandAll();
                
                Resources.resourcecnt++; //Increase the current resource count by one, as we've (obviously) just added a resource.
                Resources.resourcetypecnt[0]++; //Increase the number of sprites by one.
            }
            else
            {
                Error(1);
            }
        }

        private void Error(int errorcode)
        {
            //Displays an error message including an error code, and closes the program.
            System.Media.SystemSounds.Hand.Play();
            CustomMessageBox.Show("Love Game Maker has encountered an error and needs to close!" + Environment.NewLine + "ERROR CODE: " + errorcode.ToString(), "Love Game Maker", CustomMessageBox.eDialogButtons.OK, error);
            issaved = true;
            Application.Exit();
        }

        private void TestGame()
        {
            //Tests the game using LOVE 2D
        }

        private void Save(bool saveas)
        {
            if (!saveas)
            {
                //Save the project
            }
            else
            {
                //Save the project as something.
            }
            issaved = true;
            UpdateTitle();
        }

        private string getprojectname()
        {
            if (projectname == null)
            {
                return "Untitled";
            }
            else
            {
                return "";
            }
        }

        private void UpdateTitle()
        {
            if (issaved)
            {
                this.Text = getprojectname() + " - Love Game Maker";
            }
            else
            {
                this.Text = getprojectname() + "* - Love Game Maker";
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new PowerfulSample();
            childForm.MdiParent = this;
            childForm.Text = "Object" + childFormNumber++;
            childForm.Show();
            issaved = false;
            UpdateTitle();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            if (!issaved)
            {
                System.Media.SystemSounds.Asterisk.Play();
                DialogResult areusure = CustomMessageBox.Show("You have unsaved changes! Would you like to save your work first?", "Love Game Maker", CustomMessageBox.eDialogButtons.YesNoCancel, warning);
                if (areusure == System.Windows.Forms.DialogResult.Cancel)
                {
                    //Don't close the form!
                    e.Cancel = true;
                }
                else if (areusure == System.Windows.Forms.DialogResult.Yes)
                {
                    //Save the file before closing
                    Save(false);
                }
            }
        }

        #region All the buttons/Menu items
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(false);
        }
        
        void treeView1_MouseLeave(object sender, EventArgs e)
        {
            ontreeview = false;
        }

        void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            ontreeview = true;
        }

        private void resourceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeableTreeView1.Visible = resourceListToolStripMenuItem.Checked;
        }

        private void testbtn_Click(object sender, EventArgs e)
        {
            //TODO: Open the game in Love 2D for testing.
            TestGame();
        }

        private void testGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestGame();
        }
        
        private void spritebtn_Click(object sender, EventArgs e)
        {
            AddSprite();
        }
        #endregion

        
    }

    public class MyToolStripSystemRenderer : ToolStripSystemRenderer
    {
        public MyToolStripSystemRenderer() { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle r = e.Item.ContentRectangle;

            if (e.Item.Selected)
            {
                LinearGradientBrush b = new LinearGradientBrush(r,Color.FromArgb(255,227,224,215),Color.White,LinearGradientMode.Vertical);
                try
                {
                    e.Graphics.FillRectangle(b, e.Item.ContentRectangle);
                }
                finally
                {
                    b.Dispose();
                }
            }
            base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //Making this non-op removes the artifact line that is typically drawn on the bottom edge
            base.OnRenderToolStripBorder(e);
        }
    }
}
