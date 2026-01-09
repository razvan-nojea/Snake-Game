using atestat.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat
{
    public partial class Cre : Form
    {
        public Cre()
        {
            InitializeComponent();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag == null)
                {
                    ctrl.Location = new Point(ClientRectangle.Width / 2 - ctrl.Width / 2, ctrl.Top);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();

            Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtUser.Text.Length == 0 || txtPass.Text.Length == 0 || txtRPass.Text.Length == 0)
            {
                lblError.Text = "Completeaza toate casutele!";
                RefreshError();
                return;
            }

            if(txtPass.Text.ToString().Trim() != txtRPass.Text.ToString().Trim())
            {
                lblError.Text = "Parolele nu coincid!";
                RefreshError();
                return;
            }

            if(baza.UserExist(txtUser.Text.ToString().Trim()))
            {
                lblError.Text = "Userul acesta exista deja!";
                RefreshError();
                return;
            }

            baza.NewUser(txtUser.Text.ToString().Trim(), txtPass.Text.ToString().Trim());
            MessageBox.Show("Cont creat cu succes!");

            Form1 f = new Form1();

            Hide();
            f.Show();
        }

        private void RefreshError()
        {
            lblError.Location = new Point(ClientRectangle.Width / 2 - lblError.Width / 2, lblError.Top);
            lblError.Visible = true;
        }
    }
}
