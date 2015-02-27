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
    public partial class Roomeditor : Form
    {
        public List<Image> objects = new List<Image>();
        public string name = "";
        public List<PictureBox> pboxes = new List<PictureBox>();
        private Image missingimg = Properties.Resources.target;

        Point dragPoint = Point.Empty;
        bool dragging = false;

        public Roomeditor()
        {
            InitializeComponent();
            rm.MouseClick += rm_MouseClick;

            //Get all the objects in the project
            foreach (Resources.Types rs in Resources.resources)
            {
                if (rs.GetType() == typeof(Resources.Object))
                {
                    Resources.Object obj = (Resources.Object)rs;
                    if (obj.defaultsprite != null)
                    {
                        objects.Add(obj.defaultsprite);
                    }
                    else
                    {
                        objects.Add(missingimg);
                    }
                    objlist.Items.Add(obj.name);
                    objlist.SelectedIndex = 0;
                }
            }
        }

        void PBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Select the object!
                PictureBox pb = (PictureBox)sender;

                pb.Tag = "true";
                pb.Refresh();
            }
        }

        private void PBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                PictureBox pb = (PictureBox)sender;
                pb.Location = new Point(pb.Location.X + e.X - dragPoint.X, pb.Location.Y + e.Y - dragPoint.Y);
            }
        }

        private void PBox_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        void PBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                dragging = true;
                dragPoint = new Point(e.X, e.Y);
            }
        }

        void rm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (objlist.Items.Count >= 1 && objlist.SelectedItem != null)
                {
                    Point point = e.Location;
                    PictureBox pb = new PictureBox();
                    pb.BackColor = Color.White;
                    pb.Location = point;
                    pb.Image = objects[objlist.SelectedIndex];
                    pb.Size = new System.Drawing.Size(pb.Image.Width,pb.Image.Height);
                    pb.BackColor = System.Drawing.Color.Transparent;
                    pboxes.Add(pb);
                    pb.Tag = "false";
                    pb.MouseClick += PBox_MouseClick;
                    pb.MouseDown += PBox_MouseDown;
                    pb.MouseUp += PBox_MouseUp;
                    pb.MouseMove += PBox_MouseMove;
                    pb.Paint += PBox_Paint;
                    pb.ContextMenuStrip = objrclick;
                    rm.Controls.Add(pb);
                }
                
            }
        }

        void PBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            Console.WriteLine(pb.Tag);

            if (((string)pb.Tag) == "true")
            {
                Pen whitePen = new Pen(Color.FromArgb(144, 212, 242), 1);
                Pen blackPen = new Pen(Color.Black, 2);

                e.Graphics.DrawRectangle(blackPen, new Rectangle(0, 0, pb.Image.Width - 1, pb.Image.Height - 1));
                e.Graphics.DrawRectangle(whitePen, new Rectangle(0, 0, pb.Image.Width - 1, pb.Image.Height - 1));
            }
        }

        private void objrclick_Opening(object sender, CancelEventArgs e)
        {
            //PictureBox pb = (PictureBox)sender;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Delete all selected objects
            foreach (PictureBox pb in pboxes)
            {
                if ((string)pb.Tag == "true")
                {
                    rm.Controls.Remove(pb);
                }
            }
        }
    }
}
