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
    using System;
    using System.Windows.Forms;

    internal partial class MessageForm : Form
    {
        internal MessageForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            //DPI adjustment
            Graphics g = this.CreateGraphics();
            float dx;

            try
            {
                dx = g.DpiX;
                MessageBox.Show(dx.ToString()+" , "+this.Width.ToString()+" , " + this.Height.ToString());
                if (dx == 96)
                {
                    this.Width = 471;
                    this.Height = 171;
                    //MessageBox.Show(btnYes.Location.ToString());
                    btnYes.Size = new System.Drawing.Size(86,24);
                    btnYes.Location = new System.Drawing.Point(166,16);
                    //MessageBox.Show(btnYes.Location.ToString());
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
            }
        }
    }
}
