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
        public static bool error = false;

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
            CorrectDPI();
        }

        private void CorrectDPI()
        {
            //Corrects the form to be the right size according to the current DPI.
            Graphics g = this.CreateGraphics();
            float dx;

            try
            {
                dx = g.DpiX;

                this.Width = Main.CorrectDPIvalues(471, dx);
                this.Height = Main.CorrectDPIvalues(171, dx);
                btnYes.Size = new System.Drawing.Size(Main.CorrectDPIvalues(86, dx), Main.CorrectDPIvalues(24, dx));
                btnYes.Location = new System.Drawing.Point(Main.CorrectDPIvalues(166, dx), Main.CorrectDPIvalues(16, dx));
                btnNo.Size = new System.Drawing.Size(Main.CorrectDPIvalues(86, dx), Main.CorrectDPIvalues(24, dx));
                btnNo.Location = new System.Drawing.Point(Main.CorrectDPIvalues(264, dx), Main.CorrectDPIvalues(16, dx));
                btnCancel.Size = new System.Drawing.Size(Main.CorrectDPIvalues(86, dx), Main.CorrectDPIvalues(24, dx));
                btnCancel.Location = new System.Drawing.Point(Main.CorrectDPIvalues(360, dx), Main.CorrectDPIvalues(16, dx));
                btnOK.Size = new System.Drawing.Size(Main.CorrectDPIvalues(86, dx), Main.CorrectDPIvalues(24, dx));
                if (!btnOK.Visible) btnOK.Location = btnCancel.Location;
                picImage.Size = new System.Drawing.Size(Main.CorrectDPIvalues(Main.DPIIconSize(dx), dx), Main.CorrectDPIvalues(Main.DPIIconSize(dx), dx));
                picImage.Location = new System.Drawing.Point(Main.CorrectDPIvalues(25 - (Main.DPIIconSize(dx) - 32), dx), Main.CorrectDPIvalues(29 - (Main.DPIIconSize(dx) - 32), dx));
                lblText.Size = new System.Drawing.Size(Main.CorrectDPIvalues(29, dx), Main.CorrectDPIvalues(15, dx));
                if (!error) lblText.Location = new System.Drawing.Point(Main.CorrectDPIvalues(65, dx), Main.CorrectDPIvalues(37, dx)); else lblText.Location = new System.Drawing.Point(Main.CorrectDPIvalues(65, dx), Main.CorrectDPIvalues(15,dx));
                
            }
            finally
            {
                g.Dispose();
            }
        }
    }
}
