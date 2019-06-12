using System;
using System.Collections.Generic;
using System.Drawing;

namespace AccuracyTester
{
  [Serializable]
  public class DefaultGame
  {
    public List<Ball> balls;

    private int width;
    private int height;
    private Random random;
    private Ball bomb;
    public int targets;

    public DefaultGame(int width, int height)
    {
      this.width = width;
      this.height = height;
      random = new Random();
      balls = new List<Ball>();
      targets = 0;
    }

    public void Generate(int target)
    {
      Point position = new Point(random.Next(100, width - 100), random.Next(100, height - 100));

      int min, max;

      switch (target)
      {
        case 0:
          min = 40;
          max = 50;
          break;
        case 1:
          min = 50;
          max = 60;
          break;
        case 2:
          min = 60;
          max = 70;
          break;
        case 3:
        default:
          min = 70;
          max = 80;
          break;
      }

      var ball = new Ball(position, random, min, max);
      bool colide = false;

      foreach (var b in balls)
        if (b.Colide(ball))
          colide = true;

      if (colide)
      {
        Generate(target);
      }
      else
      {
        balls.Add(ball);
        targets++;
      }
    }

    public void Bomb(Point point)
    {
      bomb = new Ball(point, 50, Color.Black);
    }

    public void Draw(Graphics g)
    {
      balls.ForEach(b => b.Draw(g));

      if (bomb != null)
        bomb.Draw(g);
    }

    public void Tick()
    {
      for (int i = balls.Count - 1; i >= 0; --i)
      {
        if (balls[i].Tick())
          balls.RemoveAt(i);

        if (bomb != null)
          if (balls[i].Colide(bomb))
            balls.RemoveAt(i);
      }

      if (bomb != null)
        bomb = null;
    }

    public void Hit(Point position)
    {
      balls.ForEach(it => it.Hit(position));
    }
  }
}
