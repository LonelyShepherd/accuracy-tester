using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace AccuracyTester
{
    public partial class TimedMode : Form
    {
        private Game game;
        private Timer timer;
        private int counter;
        private string FileName;

        public TimedMode()
        {
            InitializeComponent();
            game = new Game(Width, Height);
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            counter = 0;
            timer.Start();
            DoubleBuffered = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (++counter % 2 == 0)
            {
                game.Generate();
            }
            game.Tick();
            Invalidate(true);
        }

        private void getWord_Click(object sender, EventArgs e)
        {
            givenWord.Text = GenerateWord();

        }

        string GenerateWord()
        {
            WebClient webClient = new WebClient();
            string wordlist = webClient.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
            string[] words = wordlist.Split('\n');
            Random random = new Random();
            return words[random.Next(0, words.Length - 1)];
        }

        private void TimedMode_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            game.Draw(e.Graphics);
        }

        private void TimedMode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                game.Hit(e.Location);           
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                game.Bomb(e.Location);
            }
            Invalidate(true);
        }

       
    }
}
