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

        private Image warning = Properties.Resources.warning1;

        public Main()
        {
            InitializeComponent();
            this.FormClosing += Main_Closing;
            toolStrip.Renderer = new MyToolStripSystemRenderer();
            MDIClientSupport.SetBevel(this,false);
            UpdateTitle();
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
                MessageBox.Show("You have unsaved changes! Would you like to save your work first?", "Love Game Maker", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }*/
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

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
    }

    public class MyToolStripSystemRenderer : ToolStripSystemRenderer
    {
        public MyToolStripSystemRenderer() { }


   /*Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
      Dim r As Rectangle = e.Item.ContentRectangle

      If e.Item.Selected Then
         Dim b = New LinearGradientBrush(r, Color.FromArgb(255, 227, 224, 215), Color.White, LinearGradientMode.Vertical)
         Try
            e.Graphics.FillRectangle(b, e.Item.ContentRectangle)
         Finally
            b.Dispose()
         End Try
      End If
   End Sub*/

        

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            //MessageBox.Show("");
            Console.WriteLine("OK2");
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
            Console.WriteLine("OK2");
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //Making this non-op removes the artifact line that is typically drawn on the bottom edge
            //base.OnRenderToolStripBorder(e);
            Console.WriteLine("OK");
        }
    }
}
