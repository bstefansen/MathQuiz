using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{

    public partial class Form1 : Form
    {
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();


        // These integer variables store the numbers 
        // for the addition problem. 
        int addend1;
        int addend2;

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>
        /// 
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Start the timer.
            timeLeft = 5;
            label1.Text = "5 seconds";
            timer1.Start();
        }

        public static System.Media.SystemSound Hand { get; }

        /// <summary>
        /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft < 3)
            {
                label1.BackColor = Color.Red;
            }

            if (CheckTheAnswer())
            {
                // Plays the sound associated with the Hand system event.
                SystemSounds.Hand.Play();

                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.

                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                button1.Enabled = true;
                label1.BackColor = Color.White;

            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                label1.Text = timeLeft + " seconds";
            }
            else
            {

                timer1.Stop();
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                SystemSounds.Exclamation.Play();
                label1.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                button1.Enabled = true;
                label1.BackColor = Color.White;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
