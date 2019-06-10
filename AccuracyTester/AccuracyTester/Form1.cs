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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getWord_Click(object sender, EventArgs e)
        {
         
        }

        private void givenWord_Click(object sender, EventArgs e)
        {

        }

        private void timedMode_Click(object sender, EventArgs e)
        {
            TimedMode timedMode = new TimedMode();

            if (timedMode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              
            }
        }

    private void FreeMode_Click(object sender, EventArgs e)
    {
      Default def = new Default();

      def.ShowDialog();
    }
  }
}
