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

        private void missedBullseye(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("You missed the target.");
        }

        /// <summary>
        /// Works out the distance between the centre of
        /// the circle and where the user clicked, and adds 
        /// one to the hit target score.
        /// </summary>
        private void hitBullseye(object sender, MouseEventArgs e)
        {
            hitTarget++;
            timer1.Enabled = false;

            MessageBox.Show("You were " + Convert.ToString(Math.Sqrt(Math.Pow(e.X - 50, 2) + Math.Pow(e.Y - 50, 2))) + " pixels away from the centre");
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
