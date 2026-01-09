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
using test_snake.classes;

namespace atestat
{
    public partial class Joc : Form
    {
        int id;
        int viteza;
        int fundal;
        string color;
        Image img;

        Color culoare;

        int di = -1, dj = 0, score = 0;

        List<Snake> snake = new List<Snake>();
        Item item;
        bool[,] visit = new bool[31, 46];

        Random rand = new Random();

        Timer gametime = new Timer();
        Timer drawer = new Timer();
        Timer TimePass = new Timer();

        int interval;

        int time = 0;

        public Joc(int idu)
        {
            InitializeComponent();

            id = idu;

            string user = baza.GetUser(id);

            lblUser.Text += user;

            fundal = baza.GetSetareFundal(id);
            viteza = baza.GetSetareViteza(id);
            color = baza.GetSetareCuloare(id);

            interval = 4 - viteza;

            if (interval == 3)
                interval++;

            img = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\backgrounds\" + fundal + ".png");

            if(color == "default")
            {
                culoare = Color.SeaGreen;
            }
            if (color == "midnight_blue")
            {
                culoare = Color.MidnightBlue;
            }
            if (color == "orchid")
            {
                culoare = Color.Orchid;
            }
            if (color == "gray")
            {
                culoare = Color.Gray;
            }
            if (color == "gold")
            {
                culoare = Color.Gold;
            }
            if (color == "crimson")
            {
                culoare = Color.Crimson;
            }
            if (color == "turquoise")
            {
                culoare = Color.Turquoise;
            }
            if (color == "sienna")
            {
                culoare = Color.Sienna;
            }
            if (color == "orange")
            {
                culoare = Color.Orange;
            }

            launchTimer();

        }

        private void launchTimer()
        {
            drawer.Interval = 1;
            drawer.Tick += drawdraw;
            drawer.Start();
            TimePass.Interval = 1000;
            TimePass.Tick += Time;
            TimePass.Start();
            gametime.Interval = 25 * interval;
            gametime.Tick += move;
        }

        private void drawdraw(object sender, EventArgs e)
        {
            if(grid.Visible)
            {
                drawer.Stop();
                init();
                gametime.Start();
            }
        }

        private void move(object sender, EventArgs e)
        {

            if (di == 0 && dj == 0) return;
            if (collision(snake[0].i + di, snake[0].j + dj))
            {
                gametime.Stop();
                MessageBox.Show("Jocul s-a incheiat!");
                baza.NewScore(id, score);
                Men m = new Men(id);
                Hide();
                m.Show();
                return;
            }
            if (collisionWithFood(snake[0].i + di, snake[0].j + dj))
            {
                if (item.special)
                {
                    score += (viteza * 3);
                }
                else
                {
                    score+=viteza;
                }

                lblScore.Text = "Scor: " + score;

                if (hits(snake[0].i + di, snake[0].j + dj)) return;

                snake.Add(new Snake(snake[snake.Count - 1].i, snake[snake.Count - 1].j));

                for (int i = snake.Count - 2; i >= 1; i--)
                {
                    snake[i].i = snake[i - 1].i;
                    snake[i].j = snake[i - 1].j;
                }

                snake[0].i += di;
                snake[0].j += dj;

                visit[snake[0].i, snake[0].j] = true;

                item = NewItem();
            }
            else
            {
                if (hits(snake[0].i + di, snake[0].j + dj)) return;

                visit[snake[snake.Count - 1].i, snake[snake.Count - 1].j] = false;

                for (int i = snake.Count - 1; i >= 1; i--)
                {
                    snake[i].i = snake[i - 1].i;
                    snake[i].j = snake[i - 1].j;
                }

                snake[0].i += di;
                snake[0].j += dj;

                visit[snake[0].i, snake[0].j] = true;
            }

            drawgame.Game(grid, snake, culoare,  item, img);
        }

        private void Time(object sender, EventArgs e)
        {
            time++;
            int minutes = time / 60;
            int seconds = time % 60;

            if (minutes < 10)
            {
                lblTime.Text = "0" + minutes;
            }
            else
            {
                lblTime.Text = "" + minutes;
            }

            if (seconds < 10)
            {
                lblTime.Text += ":0" + seconds;
            }
            else
            {
                lblTime.Text += ":" + seconds;
            }
        }

        private bool hits(int i, int j)
        {
            if (visit[i, j])
            {
                gametime.Stop();
                MessageBox.Show("Te-ai muscat singur!");
                baza.NewScore(id, score);
                Men m = new Men(id);
                Hide();
                m.Show();
                return true;
            }

            return false;
        }

        private bool collisionWithFood(int i, int j)
        {
            return i == item.i && j == item.j;
        }

        private void Joc_KeyDown(object sender, KeyEventArgs e)
        {
            int ci = di;
            int cj = dj;

            di = dj = 0;

            switch (e.KeyCode)
            {
                case Keys.W:
                    if(ci != 1)
                    {
                        di = -1;
                    }
                    break;
                case Keys.S:
                    if (ci != -1)
                    {
                        di = 1;
                    }
                    break;
                case Keys.D:
                    if (cj != -1)
                    {
                        dj = 1;
                    }
                    break;
                case Keys.A:
                    if (cj != 1)
                    {
                        dj = -1;
                    }
                    break;
            }

            if(di == dj && di == 0)
            {
                di = ci;
                dj = cj;
            }
        }

        private bool collision(int i, int j)
        {
            return i < 1 || j < 1 || i > 30 || j > 45;
        }

        private void init()
        {
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 45; j++)
                {
                    visit[i, j] = false;
                }
            }

            snake.Add(new Snake(20, 25));
            snake.Add(new Snake(21, 25));
            visit[20, 25] = true;
            visit[21, 25] = true;

            item = NewItem();

            drawgame.Game(grid, snake, culoare, item, img);
        }

        private void btnContinua_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            btnContinua.Visible = false;
            lblPauza.Visible = false;

            gametime.Start();
            TimePass.Start();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Men m = new Men(id);

            Hide();
            m.Show();
        }

        private void grid_VisibleChanged(object sender, EventArgs e)
        {
            if(grid.Visible)
            {
                init();
            }
        }

        private Item NewItem()
        {
            int itemi = snake[0].i;
            int itemj = snake[0].j;

            while (visit[itemi, itemj])
            {
                itemi = rand.Next(1, 31);
                itemj = rand.Next(1, 46);
            }

            bool special;

            special = rand.Next(1, 101) == 77;

            return new Item(itemi, itemj, special);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            gametime.Stop();
            TimePass.Stop();

            btnBack.Visible = true;
            btnContinua.Visible = true;
            lblPauza.Visible = true;
        }
    }
}
