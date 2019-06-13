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
   
            Invalidate(true);
        }

        void ShowStats()
        {
            timer.Stop();
            timeTimer.Stop();
            generationTimer.Stop();

            panel1.Visible = true;
            label10.Text = label4.Text;
            label7.Text = label3.Text;
            label13.Text = string.Format("{0}/{1}", hits, clicks);
            label14.Text = string.Format("{0:0.##}%", (hits * 100) / (clicks * 1.0));
        }


        public void SelectCorrect(Graphics g)
        {
            if (!givenWordPlayer.Text.StartsWith(word))
            {
                ShowStats();
                return;
            }

            Brush brush = new SolidBrush(Color.Yellow);
            SizeF size = g.MeasureString(word, givenWordPlayer.Font);
            g.FillRectangle(brush, givenWordPlayer.Location.X + 5, givenWordPlayer.Location.Y, size.Width - 9, givenWordPlayer.Height);

            brush.Dispose();

            if (givenWordPlayer.Text == word)
                ShowStats();
        }

        private void Restart()
        {
            label3.Text = "00:00";
            now = DateTime.Now;

            word = "";
            GenerateWordPlayer();
            points = hits = clicks = 0;
            label4.Text = "0";

            game.balls.Clear();

            panel1.Visible = false;

            timer.Start();
            timeTimer.Start();
            generationTimer.Start();

            Invalidate();
        }


       
        /// /////////////////////// CPU ////////////////////////////////////////
        
        public void SelectCorrectCPU(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Green);
            SizeF size = g.MeasureString(word, givenWordCPU.Font);
            g.FillRectangle(brush, givenWordCPU.Location.X + 5, givenWordCPU.Location.Y, size.Width - 9, givenWordCPU.Height);

            brush.Dispose();

            if (givenWordCPU.Text == wordCPU)
            {
                ShowStats();
                Console.WriteLine("CPU WINS");
            }

        }
       

      

        public char ComputerGuessing()
        {
            Random random = new Random();
            letter = (char)random.Next(97, 123);
            return letter;
        }




        void GenerateWordPlayer()
        {
            WebClient webClient = new WebClient();
            string wordlist = webClient.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
            string[] words = wordlist.Split('\n');

            Random random = new Random();
            givenWordPlayer.Text = words[random.Next(0, words.Length - 1)];
            givenWordPlayer.Left = (ClientSize.Width - givenWordCPU.Size.Width) / 2;
        }

        void GenerateWordCPU()
        {
            WebClient webClient = new WebClient();
            string wordlist = webClient.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
            string[] words = wordlist.Split('\n');

            Random random = new Random();
            givenWordCPU.Text = words[random.Next(0, words.Length - 1)];
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
    }
}
