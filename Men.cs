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
    public partial class Men : Form
    {
        private string user;
        private int id;
        private string pass;
        private int credits;
        private int max_score;
        private int indexFundal;

        private string caleFundal = AppDomain.CurrentDomain.BaseDirectory + @"resources\backgrounds\";

        Random random = new Random();
        Timer freshly = new Timer();

        public Men(int idu)
        {
            InitializeComponent();
            HideSubPnl();
            InitTimer();
            baza.InitDgvScor(dgvScor);
            baza.InitDgvBani(dgvBani);

            id = idu;
            user = baza.GetUser(id);
            pass = baza.GetPass(id);
            credits = baza.GetCredits(id);

            lblCrediteMagazin.Text += credits;

            baza.InitCmbColor(cmbColorSnake, id);

            foreach(string s in cmbColorSnake.Items)
            {
                foreach(Control ctrl in panelMagazin.Controls)
                {
                    if(ctrl.Tag != null && ctrl.Tag.ToString() == s)
                    {
                        ctrl.Enabled = false;
                    }
                }
            }

            max_score = baza.GetMaxScore(id);

            lblMaxScore.Text = max_score.ToString();
            lblMaxScore.Location = new Point(panelJoaca.Width / 2 - lblMaxScore.Width / 2, lblMaxScore.Top);
            
            lblUser.Visible = false;
            lblUser.Text = user;
            lblUser.Location = new Point(panelAcasa.Width / 2 - lblUser.Width / 2, lblUser.Top);
            lblUser.Visible = true;

            DutePanel();

            panelAcasa.Location = new Point(206, 0);
        }

        private void InitTimer()
        {
            freshly.Interval = 500;
            freshly.Tick += freshfresh;
            freshly.Start();
        }

        private void freshfresh(object sender, EventArgs e)
        {
            int a = random.Next(0, 256);
            int b = random.Next(0, 256);
            int c = random.Next(0, 256);

            lblFresh.ForeColor = Color.FromArgb(a, b, c);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = false;

            if (MessageBox.Show("Doresti sa iesi?", "Inchide aplicatia",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void HideSubPnl()
        {
            subpanelSetari.Visible = false;
        }

        private void DutePanel()
        {
            panelAcasa.Location = new Point(1000, 0);
            panelJoaca.Location = new Point(1000, 0);
            panelSetariCont.Location = new Point(1000, 0);
            panelSetariJoc.Location = new Point(1000, 0);
            panelMagazin.Location = new Point(1000, 0);
            panelAjutor.Location = new Point(1000, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = !subpanelSetari.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = false;
            if (panelAcasa.Left != 206)
            {
                user = baza.GetUser(id);

                lblUser.Visible = false;
                lblUser.Text = user;
                lblUser.Location = new Point(panelAcasa.Width / 2 - lblUser.Width / 2, lblUser.Top);
                lblUser.Visible = true;

                DutePanel();
                panelAcasa.Location = new Point(206, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = false;

            if(panelJoaca.Left != 206)
            {
                DutePanel();
                panelJoaca.Location = new Point(206, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = false;

            if (panelMagazin.Left != 206)
            {
                lblCrediteMagazin.Text = "Creditele tale: " + credits;
                DutePanel();
                panelMagazin.Location = new Point(206, 0);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            user = baza.GetUser(id);
            pass = baza.GetPass(id);
            credits = baza.GetCredits(id);

            txtUserSetari.Text = user;
            txtParolaSetari.Text = pass;
            txtCrediteSetari.Text = "" + credits;

            subpanelSetari.Visible = false;

            if (panelSetariCont.Left != 206)
            {
                DutePanel();
                panelSetariCont.Location = new Point(206, 0);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            txtUserSetari.Enabled = true;
            btnSaveChange.Enabled = true;            
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            string newUser = txtUserSetari.Text.ToString().Trim();

            if(user == newUser)
            {
                btnSaveChange.Enabled = false;
                txtUserSetari.Enabled = false;

                return;
            }

            if(baza.UserExist(newUser))
            {
                MessageBox.Show("Acest user exista deja!");
                txtUserSetari.Text = user;
                return;
            }

            if(newUser.Length == 0)
            {
                MessageBox.Show("User invalid!");
                txtUserSetari.Text = user;
                return;
            }

            user = newUser;

            baza.UpdateUser(newUser, id);

            baza.InitDgvBani(dgvBani);
            baza.InitDgvScor(dgvScor);

            txtUserSetari.Text = user;
            txtUserSetari.Enabled = false;
            btnSaveChange.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = false;

            if (panelSetariJoc.Left != 206)
            {
                string culoare = baza.GetSetareCuloare(id);
                int viteza = baza.GetSetareViteza(id);
                int fundal = baza.GetSetareFundal(id);

                indexFundal = fundal;

                lblBackgroundIndex.Text = "" + fundal;
                lblBackgroundIndex.Location = new Point(panelSetariJoc.Width / 2 - lblBackgroundIndex.Width / 2, lblBackgroundIndex.Top);

                tbarSpeed.Value = viteza;

                cmbColorSnake.SelectedItem = culoare;

                picFundal.Image = Image.FromFile(caleFundal + fundal + ".png");

                DutePanel();
                panelSetariJoc.Location = new Point(206, 0);
            }
        }

        private void cmbColorSnake_SelectedIndexChanged(object sender, EventArgs e)
        {
            string culoare = cmbColorSnake.Text;
            int viteza = tbarSpeed.Value;
            int fundal = indexFundal;

            baza.UpdateSettings(id, culoare, viteza, fundal);
        }

        private void tbarSpeed_Scroll(object sender, EventArgs e)
        {
            string culoare = cmbColorSnake.Text;
            int viteza = tbarSpeed.Value;
            int fundal = indexFundal;

            baza.UpdateSettings(id, culoare, viteza, fundal);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if(indexFundal < 5)
            {
                btnLeft.Enabled = true;
                btnRight.Enabled = true;
                indexFundal++;

                if (indexFundal == 5)
                    btnRight.Enabled = false;

                lblBackgroundIndex.Text = "" + indexFundal;
                lblBackgroundIndex.Location = new Point(panelSetariJoc.Width / 2 - lblBackgroundIndex.Width / 2, lblBackgroundIndex.Top);

                picFundal.Image = Image.FromFile(caleFundal + indexFundal + ".png");

                string culoare = cmbColorSnake.Text;
                int viteza = tbarSpeed.Value;
                int fundal = indexFundal;

                baza.UpdateSettings(id, culoare, viteza, fundal);
            }
            else
            {
                btnRight.Enabled = false;
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (indexFundal > 1)
            {
                btnLeft.Enabled = true;
                btnRight.Enabled = true;
                indexFundal--;

                if (indexFundal == 1)
                    btnLeft.Enabled = false;

                lblBackgroundIndex.Text = "" + indexFundal;
                lblBackgroundIndex.Location = new Point(panelSetariJoc.Width / 2 - lblBackgroundIndex.Width / 2, lblBackgroundIndex.Top);

                picFundal.Image = Image.FromFile(caleFundal + indexFundal + ".png");

                string culoare = cmbColorSnake.Text;
                int viteza = tbarSpeed.Value;
                int fundal = indexFundal;

                baza.UpdateSettings(id, culoare, viteza, fundal);
            }
            else
            {
                btnLeft.Enabled = false;
            }
        }

        private void Cumpara(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string tag = btn.Tag.ToString();
            
            if(credits - 150 >= 0)
            {
                credits -= 150;

                txtCrediteSetari.Text = "" + credits;
                lblCrediteMagazin.Text = "Creditele tale: " + credits;

                baza.NewPurchase(tag, id, credits);

                baza.InitCmbColor(cmbColorSnake, id);

                foreach (Control ctrl in panelMagazin.Controls)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == tag)
                    {
                        ctrl.Enabled = false;
                    }
                }

                baza.InitDgvBani(dgvBani);
            }
            else
            {
                MessageBox.Show("Nu ai destule credite! Joaca ca sa le castigi!");
            }
        }

        private void btnAjutor_Click(object sender, EventArgs e)
        {
            subpanelSetari.Visible = false;

            if (panelAjutor.Left != 206)
            {
                DutePanel();
                panelAjutor.Location = new Point(206, 0);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Miscarea Sarpelui:\r\n         Sus - W\r\n          Jos - S\r\n       Stanga - A\r\n       Dreapta - D");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scopul e sa mananci cat mai multe mere si sa devii cel mai lung Sarpe.");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mancand mere, castigi credite, care pot fi folosite la cumpararea culorilor de Sarpe. Cu cat viteza Sarpelui e mai mare, cu atat castigi mai multe credite!");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Daca capul Sarpelui da in corpul lui sau iese din zona de joc, jocul se incheie.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Joc j = new Joc(id);

            Hide();
            j.Show();
        }
    }
}
