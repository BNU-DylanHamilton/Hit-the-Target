using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hit_the_Target
{
    public partial class targetForm : Form
    {
        private int x, y, hitTarget;

        private Random rand = new Random();

        public targetForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// This method starts the timer with the normal monkey set in the 
        /// picture box and sets the text of the labels.
        /// </summary>
        private void startTimer(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            scoreLabel.Text = "Score: " + Convert.ToString(hitTarget);
        }

        private void stopTimer(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void hitBullseye(object sender, EventArgs e)
        {
            hitTarget++;
            timer1.Enabled = false;
            
            //MessageBox.Show("You were " + Convert.ToString(Math.Sqrt(Math.Pow(targetPictureBox.Width - 50, 2) + Math.Pow(targetPictureBox.Height - 50, 2)) <= radius));
        }

        private void missedBullseye(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("You missed the target.");
        }

        private void closeApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This method sets up a timer that changes the position of the
        /// monkey as the timers ticks on.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            x = rand.Next(Width - 100);
            y = rand.Next(Height - 100);
            targetPictureBox.Left = x;
            targetPictureBox.Top = y;
            Refresh();
        }
    }
}
