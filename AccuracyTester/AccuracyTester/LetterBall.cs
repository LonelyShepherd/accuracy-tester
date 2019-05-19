using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccuracyTester
{
    [Serializable]
    public class LetterBall
    {
        private Font font;

        private Point position;

        private Color color;

        private int radius;

        private static readonly Color[] COLORS = { Color.Orange, Color.Blue, Color.Green };
        private int colorIndex;
        private bool hit;
        private int points;

        public LetterBall(Point position, Random random)
        {
            this.position = position;
            this.colorIndex = random.Next(COLORS.Length);
            this.color = COLORS[colorIndex];
            this.radius = random.Next(40, 100);
            this.hit = false;
        }

        public char GenerateLetter()
        {
            Random random = new Random();
            int letter = random.Next(97, 122);

            return (char)letter;
        }

        public LetterBall(Point position, int radius, Color color)
        {
            this.position = position;
            this.color = color;
            this.radius = radius;
            this.hit = false;
        }

        public int Hit(Point position)
        {
            hit = distance(this.position, position) <= radius * radius;
            points = 0;
            if (hit)
            {
                color = Color.Red;
                points = (colorIndex + 1) * 5;         
            }
            return points;
        }

        public bool Colide(LetterBall ball)
        {
            int dist = distance(position, ball.position);
            return (radius + ball.radius) * (radius + ball.radius) >= dist;
        }

        private int distance(Point p1, Point p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X)
                + (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }


        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, position.X - radius, position.Y - radius, 2 * radius, 2 * radius);

            font = new Font("Ariel",12);
            Brush frontcolor = new SolidBrush(Color.Black);
            g.DrawString("420",font ,frontcolor, position.X-radius/10, position.X-radius/10);
            
            brush.Dispose();
        }

        public bool Tick()
        {
            if (hit)
            {
                return true;
            }
            colorIndex = (colorIndex + 1) % 3;
            color = COLORS[colorIndex];
            radius -= 5;
            return radius <= 10;
        }
    }
}
