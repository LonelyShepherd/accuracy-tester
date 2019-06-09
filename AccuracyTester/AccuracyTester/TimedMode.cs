using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace AccuracyTester
{
  public partial class TimedMode : Form
  {
    private Game game;
    private Timer timer;
    private Timer timeTimer;
    private Timer generationTimer;
    private string word;
    private int points;
    private DateTime now;

    public TimedMode()
    {
      InitializeComponent();
      game = new Game(Width, Height);
      
      timer = new Timer();
      timer.Interval = 100;
      timer.Tick += new EventHandler(timer_Tick);

      timeTimer = new Timer();
      timeTimer.Interval = 1000;
      timeTimer.Tick += new EventHandler(elapsed);

      generationTimer = new Timer();
      generationTimer.Interval = 600;
      generationTimer.Tick += new EventHandler(generate);

      points = 0;

      now = DateTime.Now;

      word = "";

      timer.Start();
      timeTimer.Start();
      generationTimer.Start();

      DoubleBuffered = true;
      GenerateWord();
    }

    void elapsed(object sender, EventArgs e)
    {
      var elapsed = DateTime.Now - now;

      label2.Text = elapsed.ToString(@"mm\:ss");
    }

    void generate(object sender, EventArgs e)
    {
      game.Generate();
    }

    void timer_Tick(object sender, EventArgs e)
    {
      game.Tick();
      Invalidate(true);
    }

    private void getWord_Click(object sender, EventArgs e)
    {
    }

    public void SelectCorrect(Graphics g)
    {
      if (!givenWord.Text.StartsWith(word))
      {
        label2.Text = "00:00";
        now = DateTime.Now;

        word = "";
        GenerateWord();
        points = 0;
        label4.Text = "0";

        Invalidate();
        return;
      }

      Brush brush = new SolidBrush(Color.Yellow);
      SizeF size = g.MeasureString(word, givenWord.Font);
      g.FillRectangle(brush, givenWord.Location.X + 5, givenWord.Location.Y, size.Width - 9, givenWord.Height);

      brush.Dispose();
    }

    void GenerateWord()
    {
      WebClient webClient = new WebClient();
      string wordlist = webClient.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
      string[] words = wordlist.Split('\n');

      Random random = new Random();
      givenWord.Text = words[random.Next(0, words.Length - 1)];
      givenWord.Left = (ClientSize.Width - givenWord.Size.Width) / 2;
    }

    private void TimedMode_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.Clear(Color.White);
      game.Draw(e.Graphics);

      SelectCorrect(e.Graphics);
    }

    private void TimedMode_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        foreach (var it in game.balls)
        {
          it.Hit(e.Location);

          if (it.hit)
          {
            word += it.letter;
            points += it.points;
            label4.Text = points.ToString();
          }
        }
      }

      else if (e.Button == MouseButtons.Right)
      {
        game.Bomb(e.Location);
      }

      Invalidate(true);
    }
  }
}
