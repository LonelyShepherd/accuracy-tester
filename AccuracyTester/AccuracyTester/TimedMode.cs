using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    private int clicks;
    private int hits;



    public TimedMode()
    {
      InitializeComponent();
      game = new Game(Width, Height);
      
      timer = new Timer();
      timer.Interval = 70;
      timer.Tick += new EventHandler(timer_Tick);

      timeTimer = new Timer();
      timeTimer.Interval = 1000;
      timeTimer.Tick += new EventHandler(elapsed);

      generationTimer = new Timer();
      generationTimer.Interval = 400;
      generationTimer.Tick += new EventHandler(generate);

      points = 0;
      clicks = 0;
      hits = 0;

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

    void ShowStats()
    {
      timer.Stop();
      timeTimer.Stop();
      generationTimer.Stop();

      panel1.Visible = true;
      label10.Text = label4.Text;
      label7.Text = label2.Text;
      label13.Text = string.Format("{0}/{1}", hits, clicks);
      label14.Text = string.Format("{0:0.##}%", (hits * 100) / (clicks * 1.0));
    }

    public void SelectCorrect(Graphics g)
    {
      if (!givenWord.Text.StartsWith(word))
      {
        ShowStats();
        return;
      }

      Brush brush = new SolidBrush(Color.Yellow);
      SizeF size = g.MeasureString(word, givenWord.Font);
      g.FillRectangle(brush, givenWord.Location.X + 5, givenWord.Location.Y, size.Width - 9, givenWord.Height);

      brush.Dispose();

      if (givenWord.Text == word)
        ShowStats();
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
        clicks++;

        foreach (var it in game.balls)
        {
          it.Hit(e.Location);

          if (it.hit)
          {
            word += it.letter;

            if (givenWord.Text.StartsWith(word))
            {
              hits++;
              points += it.points;
              label4.Text = points.ToString();
            }
          }
        }
      }

      else if (e.Button == MouseButtons.Right)
      {
        game.Bomb(e.Location);
      }

      Invalidate(true);
    }

    private void Restart()
    {
      label2.Text = "00:00";
      now = DateTime.Now;

      word = "";
      GenerateWord();
      points = hits = clicks = 0;
      label4.Text = "0";

      game.balls.Clear();

      panel1.Visible = false;

      timer.Start();
      timeTimer.Start();
      generationTimer.Start();

      Invalidate();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      Restart();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      Close();
    }

        private void saveGame_Click(object sender, EventArgs e)
        {
          
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
           
        }
    }
}
