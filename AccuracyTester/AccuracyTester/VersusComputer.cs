using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccuracyTester
{
  public partial class VersusComputer : Form
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

    private Timer sleepNow;
    private Timer sleepNow1;
    private Timer sleepNow2;
    private Timer sleepNow3;


    private char letter;
    private string wordCPU;

    public VersusComputer()
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
      wordCPU = "";

      timer.Start();
      timeTimer.Start();
      generationTimer.Start();

      GenerateWordCPU();
      GenerateWordPlayer();

      InitTimer();
      InitTimer1();
      InitTimer2();
      InitTimer3();

      DoubleBuffered = true;
    }

    public void InitTimer()
    {
      sleepNow = new Timer();
      sleepNow.Tick += new EventHandler(pleaseWait);
      sleepNow.Interval = 13000;
      sleepNow.Start();
    }

    public void InitTimer1()
    {
      sleepNow1 = new Timer();
      sleepNow1.Tick += new EventHandler(PleaseWait1);
      sleepNow1.Interval = 25000;
      sleepNow1.Start();
    }

    public void InitTimer2()
    {
      sleepNow2 = new Timer();
      sleepNow2.Tick += new EventHandler(PleaseWait2);
      sleepNow2.Interval = 43000;
      sleepNow2.Start();
    }

    public void InitTimer3()
    {
      sleepNow3 = new Timer();
      sleepNow3.Tick += new EventHandler(PleaseWait3);
      sleepNow3.Interval = 60000;
      sleepNow3.Start();
    }

    private void PleaseWait3(object sender, EventArgs e)
    {
      char[] letters = givenWordCPU.Text.ToCharArray();
      Random random = new Random();
      char guess = (char)random.Next(97, 123);

      while (true)
      {
        if (guess == letters[8])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }
      while (true)
      {
        if (guess == letters[9])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }
      sleepNow3.Stop();
    }

    void pleaseWait(object sender, EventArgs e)
    {

      char[] letters = givenWordCPU.Text.ToCharArray();
      Random random = new Random();
      char guess = (char)random.Next(97, 123);
      wordCPU = "";

      while (true)
      {
        if (guess == letters[0])
        {
          Console.WriteLine("I guessed " + guess);               
          wordCPU += guess.ToString();
          break;
        }
        Console.WriteLine(guess);
        guess = (char)random.Next(97, 123);

      }

      while (true)
      {
        if (guess == letters[1])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);

      }

      sleepNow.Stop();
    }

    void PleaseWait1(object sender, EventArgs e)
    {
      char[] letters = givenWordCPU.Text.ToCharArray();
      Random random = new Random();
      char guess = (char)random.Next(97, 123);


      while (true)
      {
        if (guess == letters[2])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }

      while (true)
      {
        if (guess == letters[3])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }

      while (true)
      {
        if (guess == letters[4])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }

      sleepNow1.Stop();
    }

    void PleaseWait2(object sender, EventArgs e)
    {
      char[] letters = givenWordCPU.Text.ToCharArray();
      Random random = new Random();
      char guess = (char)random.Next(97, 123);


      while (true)
      {
        if (guess == letters[5])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }

      while (true)
      {
        if (guess == letters[6])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }

      while (true)
      {
        if (guess == letters[7])
        {
          Console.WriteLine("I guessed " + guess);
          wordCPU += guess.ToString();
          break;
        }
        guess = (char)random.Next(97, 123);
      }

      sleepNow2.Stop();
    }




    void elapsed(object sender, EventArgs e)
    {
      var elapsed = DateTime.Now - now;

      label3.Text = elapsed.ToString(@"mm\:ss");
    }

    void generate(object sender, EventArgs e)
    {
      game.Generate();
    }

    void timer_Tick(object sender, EventArgs e)
    {
      game.Tick();

      if (givenWordCPU.Text.Equals(wordCPU))
      {
        winMessage.Text = "COMPUTER WON!\nBut your stats look great!";
        winMessage.Left = (ClientSize.Width - winMessage.Size.Width) / 2;
        ShowStats();
      }

      Invalidate(true);
    }

    void ShowStats()
    {
      timer.Stop();
      timeTimer.Stop();
      generationTimer.Stop();
            sleepNow.Stop();
            sleepNow1.Stop();
            sleepNow2.Stop();
            sleepNow3.Stop();

      panel1.Visible = true;
      label10.Text = label4.Text;
      label7.Text = label3.Text;
      label13.Text = string.Format("{0}/{1}", hits, clicks);
      var hitsPerClicks = (hits * 100) / (clicks * 1.0);
      label14.Text = string.Format("{0:0.##}%", double.IsNaN(hitsPerClicks) ? 0 : hitsPerClicks);
    }

    public void SelectCorrect(Graphics g)
    {
      if (!givenWordPlayer.Text.StartsWith(word))
      {
        ShowStats();
        winMessage.Text = "Wrong letter, you lost!";
        winMessage.Left = (ClientSize.Width - winMessage.Size.Width) / 2;
        return;
      }

      Brush brush = new SolidBrush(Color.Yellow);
      SizeF size = g.MeasureString(word, givenWordPlayer.Font);
      g.FillRectangle(brush, givenWordPlayer.Location.X + 5, givenWordPlayer.Location.Y, size.Width - 9, givenWordPlayer.Height);

      brush.Dispose();

      if (givenWordPlayer.Text == word)
      {
        ShowStats();
        winMessage.Text = "YOU WON!";
        winMessage.Left = (ClientSize.Width - winMessage.Size.Width) / 2;
      }

    }

    private void Restart()
    {
      label3.Text = "00:00";
      now = DateTime.Now;

      word = "";
      wordCPU = "";
      GenerateWordPlayer();
      GenerateWordCPU();
      points = hits = clicks = 0;
      label4.Text = "0";
      game.balls.Clear();

      panel1.Visible = false;

      timer.Start();
      timeTimer.Start();
      generationTimer.Start();

      InitTimer();
      InitTimer1();
      InitTimer2();
      InitTimer3();

      Invalidate();
    }

    public void SelectCorrectCPU(Graphics g)
    {
      Brush brush = new SolidBrush(Color.LightGreen);
      SizeF size = g.MeasureString(wordCPU, givenWordCPU.Font);
      g.FillRectangle(brush, givenWordCPU.Location.X + 5, givenWordCPU.Location.Y, size.Width - 9, givenWordCPU.Height);

      brush.Dispose();
    }


    void GenerateWordPlayer()
    {
      WebClient webClient = new WebClient();
      string wordlist = webClient.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
      string[] words = wordlist.Split('\n');

      Random random = new Random();
      givenWordPlayer.Text = words[random.Next(0, words.Length - 1)];
      givenWordPlayer.Left = (ClientSize.Width - givenWordPlayer.Size.Width) / 2;
    }

    void GenerateWordCPU()
    {
      WebClient webClient = new WebClient();
      string wordlist = webClient.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
      string[] words = wordlist.Split('\n');

      Random random = new Random();

      givenWordCPU.Text = words[random.Next(0, words.Length - 1)];

      while (givenWordCPU.Text.Length != 10)
      {
        givenWordCPU.Text = words[random.Next(0, words.Length - 1)];
      }


      givenWordCPU.Left = (ClientSize.Width - givenWordCPU.Size.Width) / 2;
    }

    private void button1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void VersusComputer_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.Clear(Color.White);
      game.Draw(e.Graphics);

      SelectCorrect(e.Graphics);
      SelectCorrectCPU(e.Graphics);
    }

    private void VersusComputer_MouseClick_1(object sender, MouseEventArgs e)
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

            if (givenWordPlayer.Text.StartsWith(word))
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

    private void button1_Click_1(object sender, EventArgs e)
    {
      Restart();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void givenWordCPU_Paint(object sender, PaintEventArgs e)
    {


    }

    private void ComputerWord_Click(object sender, EventArgs e)
    {

    }
  }
}
