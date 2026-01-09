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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach(Control ctrl in this.Controls)
            {
                if(ctrl.Tag == null)
                {
                    ctrl.Location = new Point(ClientRectangle.Width / 2 - ctrl.Width / 2, ctrl.Top);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cre c = new Cre();

            Hide();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                lblError.Text = "Completeaza toate casutele!";
                RefreshError();
                return;
            }

            if (!baza.UserExist(txtUser.Text.ToString().Trim()))
            {
                lblError.Text = "Userul acesta nu exista!";
                RefreshError();
                return;
            }

            if(!baza.PassOk(txtPass.Text.ToString().Trim(), txtUser.Text.ToString().Trim()))
            {
                lblError.Text = "Parola gresita!";
                RefreshError();
                return;
            }

            int id = baza.GetId(txtUser.Text.ToString().Trim());

            Men m = new Men(id);

            Hide();
            m.Show();
        }

        private void RefreshError()
        {
            lblError.Location = new Point(ClientRectangle.Width / 2 - lblError.Width / 2, lblError.Top);
            lblError.Visible = true;
        }
    }
}
