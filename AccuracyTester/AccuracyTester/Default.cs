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

      dificulty = target = duration = 0;

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

      //now = DateTime.Now;

      timer.Start();
      //timeTimer.Start();
      // generationTimer.Start();

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

      label8.Text = (elapsed.Minutes * 60 + elapsed.Seconds).ToString();
    }

    void generate(object sender, EventArgs e)
    {
      game.Generate();
    }

    private void Default_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.Clear(Color.White);
      game.Draw(e.Graphics);
    }
  }
}
