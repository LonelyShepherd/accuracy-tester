using System;
using System.Drawing;

namespace AccuracyTester
{
  [Serializable]
  public class LetterBall
  {
    private Font font;

    private Point position;

    private Color color;

    private int radius;

    private static readonly Color[] COLORS = { Color.Green, Color.Green, Color.Green };
    private int colorIndex;
    public bool hit;
    public int points;
    public char letter;

    public string genString;

    public LetterBall(Point position, Random random)
    {
      this.position = position;
      colorIndex = random.Next(COLORS.Length);
      color = COLORS[colorIndex];
      radius = random.Next(40, 81);
      hit = false;

      genString = GenerateLetter().ToString();
    }

    public char GenerateLetter()
    {
      Random random = new Random();
      letter = (char)random.Next(97, 123);

      return letter;
    }

    public LetterBall(Point position, int radius, Color color)
    {
      this.position = position;
      this.color = color;
      this.radius = radius;
      hit = false;
    }

    public void Hit(Point position)
    {
      hit = distance(this.position, position) <= radius * radius;

      if (hit)
      {
        color = Color.Red;
        points = (colorIndex + 1) * 5;
      }
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


      font = new Font("Ariel", 20);
      Brush fontcolor = new SolidBrush(Color.Black);
      SizeF size = g.MeasureString(genString, font);
      g.DrawString(genString, font, fontcolor, position.X - size.Width / 2, position.Y - size.Height / 2);

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
      radius -= 2;
      return radius <= 10;
    }
  }
}
