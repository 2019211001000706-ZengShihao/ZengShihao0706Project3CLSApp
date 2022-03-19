using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZengShihao0706Project3CLSApp
{
    public partial class frmCreative : Form
    {
        private Icon m_ready=new Icon(SystemIcons.Information,40,40);

        public frmCreative()
        {
            InitializeComponent();
        }

        private void optGenerateLog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabDest_Click(object sender, EventArgs e)
        {

        }

        private void frmCreative_Load(object sender, EventArgs e)
        {
            txtSource.Text = "D:\\Creative\\Source\\";
            txtProcessedFile.Text = "D:\\Creative\\Processed\\";
            txtDest.Text = "D:\\Creative\\Destination\\";
            optGenerateLog.Checked=true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Source text box validation
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invalid Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
            {
                errMessage.SetError(txtSource, "");
            }

            //processFile text box validation
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invalid Processed File Directory");
                txtProcessedFile.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
            {
                errMessage.SetError(txtProcessedFile, "");
            }

            //Destination text box validation
            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invalid Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
            {
                errMessage.SetError(txtDest, "");
            }

            //activate watching directory
            watchDir.EnableRaisingEvents = true;
            watchDir.Path=txtSource.Text;//D:\Creative\Source

            //code for notification
            mnuNotify.Icon = m_ready;//set icon
            mnuNotify.Visible= true;//show
            this.ShowInTaskbar = false;//hide in task bar
            this.Hide();//hide window
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            //validate source
            if (Directory.Exists(txtSource.Text))
            {
                //no error
                txtSource.BackColor = Color.White;
            }
            else
            {
                //error
                txtSource.BackColor = Color.Pink;
            }
           
        }

        private void txtProcessedFile_KeyUp(object sender, KeyEventArgs e)
        {
            //validate processed file
            if (Directory.Exists(txtProcessedFile.Text))
            {
                //no error
                txtProcessedFile.BackColor = Color.White;
            }
            else
            {
                //error
                txtProcessedFile.BackColor = Color.Pink;
            }
        }

        private void txtDest_KeyUp(object sender, KeyEventArgs e)
        {
            //validate destination
            if (Directory.Exists(txtDest.Text))
            {
                //no error
                txtDest.BackColor = Color.White;
            }
            else
            {
                //error
                txtDest.BackColor = Color.Pink;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuNotify.Visible= false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar= true;
            this.Show();
        }
    }
}
