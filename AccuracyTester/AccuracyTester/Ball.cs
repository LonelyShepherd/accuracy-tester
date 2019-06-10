using System;
using System.Drawing;

namespace AccuracyTester
{
  [Serializable]
  public class Ball
  {
    private Point position;

    private Color color;

    private int radius;

    public bool hit;
    public int points;
    public char letter;

    public string genString;

    public Ball(Point position, Random random)
    {
      this.position = position;
      color = Color.Green;
      radius = random.Next(40, 81);
      AssignPoints();

      hit = false;
    }

    public Ball(Point position, int radius, Color color)
    {
      this.position = position;
      this.color = color;
      this.radius = radius;
      hit = false;
    }

    void AssignPoints()
    {
      if (radius > 70 && radius <= 80)
        points = 2;

      if (radius > 60 && radius <= 70)
        points = 3;

      if (radius > 50 && radius <= 60)
        points = 4;

      if (radius > 40 && radius <= 50)
        points = 5;
    }

    public void Hit(Point position)
    {
      hit = distance(this.position, position) <= radius * radius;

      if (hit)
        color = Color.Red;
    }

    public bool Colide(Ball ball)
    {
      int dist = distance(position, ball.position);
      return (radius + ball.radius) * (radius + ball.radius) >= dist;
    }

    private int distance(Point p1, Point p2)
    {
      return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
    }

    public virtual void Draw(Graphics g)
    {
      Brush brush = new SolidBrush(color);
      g.FillEllipse(brush, position.X - radius, position.Y - radius, 2 * radius, 2 * radius);

      brush.Dispose();
    }

    public bool Tick()
    {
      if (hit)
      {
        return true;
      }

      radius -= 2;
      return radius <= 10;
    }
  }
}
