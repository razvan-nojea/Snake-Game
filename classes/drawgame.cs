using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_snake.classes
{
    public static class drawgame
    {
        private static Bitmap bmp;

        private static Pen pen = new Pen(Color.Black, 1);
        private static SolidBrush brush = new SolidBrush(Color.Black);

        public static void SnakePart(Graphics g, Snake snake, Color color)
        {
            Point A = new Point((snake.j - 1) * 20, (snake.i - 1) * 20);
            Size size = new Size(20, 20);
            Rectangle rec = new Rectangle(A, size);

            pen.Color = color;
            brush.Color = color;

            g.DrawRectangle(pen, rec);
            g.FillRectangle(brush, rec);
        }

        public static void Item(Graphics g, Item item)
        {
            Point A = new Point((item.j - 1) * 20, (item.i - 1) * 20);
            Size size = new Size(20, 20);
            Rectangle rec = new Rectangle(A, size);

            if (item.special)
            {
                pen.Color = Color.Gold;
                brush.Color = Color.Gold;
            }
            else
            {
                pen.Color = Color.Crimson;
                brush.Color = Color.Crimson;
            }

            g.DrawRectangle(pen, rec);
            g.FillRectangle(brush, rec);
        }

        public static void Game(Panel grid, List<Snake> snake, Color color, Item item, Image img)
        {
            bmp = new Bitmap(grid.Width, grid.Height);

            Graphics g = Graphics.FromImage(bmp);

            g.DrawImage(img, 0, 0, 900, 600);

            for (int i = 0; i < snake.Count; i++)
            {
                drawgame.SnakePart(g, snake[i], color);
            }

            drawgame.Item(g, item);

            Graphics fg = grid.CreateGraphics();

            fg.DrawImage(bmp, 0, 0);
        }
    }
}
