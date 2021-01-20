using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        // below is the player class which has two values
        // X and O 
        // by doing this we can control the player and AI symbols

        public enum Player
        {
            X, O
        }

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        // variables
        Player currentPlayer; // calling player class
        List<Button> buttons; // creating list of array of buttons
        Random rand = new Random(); // importing random number generator class
        int playerWins = 0;
        int computerWins = 0;



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender; //find which button was clicked
            currentPlayer = Player.X; // set tha player to x 
            button.Text = currentPlayer.ToString(); // change the button text to player X
            button.Enabled = false; // disable the button
            button.BackColor = System.Drawing.Color.Cyan;  //change player color to cylan
            buttons.Remove(button); // remove button from list so ai cant click it either
            Check(); // check if player won
            AImoves.Start(); //start AI timer
        }

        private void AImove(object sender, EventArgs e)
        {                AImoves.Stop();

            if (buttons.Count >0)
            {
                int index = rand.Next(buttons.Count); //generaye random numb within the buttons avail
                buttons[index].Enabled = false; // assign num to button


                currentPlayer = Player.O; //set AI with O
                buttons[index].Text = currentPlayer.ToString(); // show O on button
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon; //change color 
                buttons.Remove(buttons[index]);
                Check();

            }

        }

        private void restartGame(object sender, EventArgs e)
        {
            resetGame();
        }

        private void loadbuttons()
        {
            // function to load buttons from form to the list
            buttons = new List<Button>
            {
                button1,button2,button3,button4,button5,button6,button7,button9,button8
            };

        }

        private void resetGame()
           
        {
            //check each of the buttons with a tag of play

            foreach (Control X in this.Controls)
            {

                if (X is Button && X.Tag == "Play")

                {
                    ((Button)X).Enabled = true; // CHANGE THEM ALL BACK TO ENABLED OR  CLICKABLE
                    ((Button)X).Text = "?";  // SET TEXT TO ?
                    ((Button)X).BackColor = default(Color); //change button back to default color

                }
            }
            loadbuttons(); // run the load button function so all buttons r inserted in array
        }

       

        private void Check() // to check if player or AI won
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {

                //IF any of the above conditions are met 
                AImoves.Stop(); // stop the timer 
                MessageBox.Show("Player wins");
                playerWins++;
                label1.Text = "Player wins - " + playerWins; //update player label
                resetGame();
            }


            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {

                AImoves.Stop();
                MessageBox.Show("Computer wins ");
                computerWins++;
                label2.Text = "Computer wins - " + computerWins;
                resetGame();

            }

            }
    }


    }

