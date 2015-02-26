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
using System.Runtime.InteropServices;

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

        public static Image warning = Properties.Resources.warning1;
        public static Image error = Properties.Resources.error1;

        public static string generatedcode = "";

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

            this.AutoScaleBaseSize = new Size(5, 13);
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

            CorrectDPI();
            settings.LoadSettings();  
        }

        public static int DPIIconSize(float dx)
        {
            if (dx == 96)
            {
                return 32;
            }
            else if (dx == 120)
            {
                return 40;
            }
            else if (dx == 144)
            {
                return 48;
            }
            else if (dx == 192)
            {
                return 64;
            }
            return 32;
        }

        public static int CorrectDPIvalues(int val,float per)
        {
            //Get the x/y values to use by multiplying the current ones by the DPI percentage.
            return val * Convert.ToInt32(per) / 100;
        }

        private void CorrectDPI()
        {
            //Corrects the form to be the right size according to the current DPI.
            //TODO: Correct size of main form.
            /*float dx;
            Graphics g = this.CreateGraphics();

            try
            {
                dx = g.DpiX;
                MessageBox.Show(dx.ToString() + " , " + this.Width.ToString() + " , " + this.Height.ToString());
                if (dx == 96)
                {
                    this.Width = 471;
                    this.Height = 171;
                    btnYes.Size = new System.Drawing.Size(86, 24);
                    btnYes.Location = new System.Drawing.Point(166, 16);
                }
                else if (dx == 144)
                {
                    this.Width = 704;
                    this.Height = 261;
                    btnYes.Size = new System.Drawing.Size(129, 37);
                    btnYes.Location = new System.Drawing.Point(249, 29);
                }
            }
            finally
            {
                g.Dispose();
            }*/
        }

        private void AddSprite()
        {
            //Adds a sprite to the resource list
            if (resourcelist.GetNodeCount(true) > 0 && resourcelist.Nodes[0] != null)
            {
                Resources.resources.Add(new Resources.Sprite());
                Resources.resources[Resources.resourcecnt].name = "Sprite" + Resources.resourcecnt.ToString();
                TreeNode newsprite = resourcelist.Nodes[0].Nodes.Add(Resources.resources[Resources.resourcecnt].name);
                resourcelist.ExpandAll();
                
                Resources.resourcecnt++; //Increase the current resource count by one, as we've (obviously) just added a resource.
                Resources.resourcetypecnt[0]++; //Increase the number of sprites by one.

                //Signify we made a change and need to save.
                issaved = false;
                UpdateTitle();
            }
            else
            {
                Error(1);
            }
        }

        public static void Error(int errorcode)
        {
            //Displays an error message including an error code, and closes the program.
            System.Media.SystemSounds.Hand.Play();
            CustomMessageBox.Show("Love Game Maker has encountered an error and needs to close!" + Environment.NewLine + "ERROR CODE: " + errorcode.ToString(), "Love Game Maker", CustomMessageBox.eDialogButtons.ErrorBtn, error);
            issaved = true;
            Application.Exit();
        }

        public static void Error(int errorcode, string errorstring)
        {
            //Displays an error message including an error code, and closes the program.
            System.Media.SystemSounds.Hand.Play();
            CustomMessageBox.Show(errorstring + Environment.NewLine + "ERROR CODE: " + errorcode.ToString(), "Love Game Maker", CustomMessageBox.eDialogButtons.ErrorBtn, error);
            issaved = true;
            Application.Exit();
        }

        private void TestGame()
        {
            //Tests the game using LOVE 2D
            GeneratedCode.GenerateCode();
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
            if (sizeableTreeView1.Visible)
            {
                sizeableTreeView1.Width = 290;
            }
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
        
        private void objectbtn_Click(object sender, EventArgs e)
        {
           //
        }
        
        private void editGeneratedCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void settingsbtn_Click(object sender, EventArgs e)
        {
            options options = new options();
            options.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options options = new options();
            options.ShowDialog();
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
