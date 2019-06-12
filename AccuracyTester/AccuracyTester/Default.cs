using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccuracyTester
{
  public partial class Default : Form
  {
    private static string[] dificulties = new string[] { "Easy", "Normal", "Hard", "Insane" };
    private static string[] targets = new string[] { "Tiny", "Small", "Medium", "Large" };
    private static string[] durations = new string[] { "15 seconds", "30 seconds", "90 seconds" };

    private int dificulty;
    private int target;
    private int duration;

    private DefaultGame game;
    private Timer timer;
    private Timer timeTimer;
    private Timer generationTimer;
    private int points;
    private DateTime now;
    private int clicks;
    private int hits;
    private DateTime timeDuration;

    public Default()
    {
      InitializeComponent();

      target = 1;
      dificulty = duration = 0;

      game = new DefaultGame(Width, Height);

      timer = new Timer();
      timer.Interval = 65;
      timer.Tick += new EventHandler(timer_Tick);

      timeTimer = new Timer();
      timeTimer.Interval = 1000;
      timeTimer.Tick += new EventHandler(elapsed);

      generationTimer = new Timer();
      generationTimer.Tick += new EventHandler(generate);

      points = 0;
      clicks = 0;
      hits = 0;

      DoubleBuffered = true;
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      Previous(ref target, targets, label4);
    }

    private void Previous(ref int option, string[] options, Label label)
    {
      option--;

      if (option < 0)
        option = options.Length - 1;

      label.Text = options[option].ToString();
    }

    private void Next(ref int option, string[] options, Label label)
    {
      option++;

      if (option > options.Length - 1)
        option = 0;

      label.Text = options[option].ToString();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      Previous(ref dificulty, dificulties, label2);
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      Next(ref dificulty, dificulties, label2);
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      Next(ref target, targets, label4);
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      Previous(ref duration, durations, label6);
    }

    private void Button6_Click(object sender, EventArgs e)
    {
      Next(ref duration, durations, label6);
    }

    private void Button7_Click(object sender, EventArgs e)
    {
      StartGame();
    }

    void StartGame()
    {
      panel5.Visible = false;
      panel1.Visible = false;

      switch (dificulty)
      {
        case 0:
          generationTimer.Interval = 500;
          break;
        case 1:
          generationTimer.Interval = 450;
          break;
        case 2:
          generationTimer.Interval = 400;
          break;
        case 3:
          generationTimer.Interval = 300;
          break;
      }

      now = DateTime.Now;

      switch (duration)
      {
        case 0:
          timeDuration = now.AddSeconds(14);
          label8.Text = "15";
          break;
        case 1:
          timeDuration = now.AddSeconds(29);
          label8.Text = "30";
          break;
        case 2:
          timeDuration = now.AddSeconds(89);
          label8.Text = "90";
          break;
      }

      timer.Start();
      timeTimer.Start();
      generationTimer.Start();
    }

    void timer_Tick(object sender, EventArgs e)
    {
      game.Tick();
      Invalidate(true);
    }

    void elapsed(object sender, EventArgs e)
    {
      var elapsed = timeDuration - now;
      now = DateTime.Now;

      var calculated = elapsed.Minutes * 60 + elapsed.Seconds;

      if (calculated < 1)
      {
        timer.Stop();
        timeTimer.Stop();
        generationTimer.Stop();
        ShowStats();
      }

      label8.Text = (elapsed.Minutes * 60 + elapsed.Seconds).ToString();
    }

    void ShowStats()
    {
      panel5.Visible = true;
      panel1.Visible = true;

      label11.Text = dificulties[dificulty].ToString();
      label15.Text = targets[target].ToString();
      label13.Text = durations[duration].ToString();
      label21.Text = points.ToString();
      label28.Text = hits.ToString();
      label29.Text = clicks.ToString();
      label30.Text = game.targets.ToString();
      label17.Text = string.Format("{0:0.##}%", !double.IsNaN((hits * 100) / (clicks * 1.0)) ? (hits * 100) / (clicks * 1.0) : 0);
      label26.Text = string.Format("{0:0.##}%", (hits * 100) / (game.targets * 1.0));
    }

    void generate(object sender, EventArgs e)
    {
      game.Generate(target);
    }

    private void Default_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.Clear(Color.White);
      game.Draw(e.Graphics);
    }

    private void Default_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        clicks++;

        foreach (var it in game.balls)
        {
          it.Hit(e.Location);

          if (it.hit)
          {
            hits++;
            points += it.points;
            label10.Text = points.ToString();
          }
        }
      }

      else if (e.Button == MouseButtons.Right)
      {
        game.Bomb(e.Location);
      }

      Invalidate(true);
    }

    private void Button15_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Button9_Click(object sender, EventArgs e)
    {
      Previous(ref dificulty, dificulties, label11);
    }

    private void Button8_Click(object sender, EventArgs e)
    {
      Next(ref dificulty, dificulties, label11);
    }

    private void Button13_Click(object sender, EventArgs e)
    {
      Previous(ref target, targets, label15);
    }

    private void Button12_Click(object sender, EventArgs e)
    {
      Next(ref target, targets, label15);
    }

    private void Button11_Click(object sender, EventArgs e)
    {
      Previous(ref duration, durations, label13);
    }

    private void Button10_Click(object sender, EventArgs e)
    {
      Next(ref duration, durations, label13);
    }

    private void Button14_Click(object sender, EventArgs e)
    {
      hits = clicks = points = game.targets = 0;
      label21.Text = label10.Text = "0";
      game.balls.Clear();

      StartGame();
    }
  }
}
