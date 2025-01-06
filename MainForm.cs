using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moon_Asg6_Yahtzee_Multiplayer
{
    public partial class MainForm : Form
    {

        private List<TextBox> playerTextBoxes;


        public MainForm()
        {
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            playerTextBoxes = new List<TextBox> { playerOneTextBox, playerTwoTextBox, playerThreeTextBox, playerFourTextBox };

            this.StartPosition = FormStartPosition.Manual;
            this.Top = 16;
            this.Left = 16;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            int numberOfPlayers = (int)playerCountUpDown.Value;

            // lock UI 
            newGameButton.Enabled = false;
            playerCountUpDown.Enabled = false;
            foreach (TextBox playerTextBox in playerTextBoxes)
            {
                playerTextBox.Enabled = false;
            }

            // open one playForm per player
            for (int player = 0; player < numberOfPlayers; player++)
            {
                // Create a new PlayForm and set its Text property to the player's name
                PlayForm playForm = new PlayForm(this, player);
                playForm.Text = playerTextBoxes[player].Text;

                // (minor setup for real-time score tracking)
                playerTextBoxes[player].Text += ": ";

                playForm.StartPosition = FormStartPosition.Manual;
                playForm.Top = 16 + (int)Math.Floor((decimal)player / 2) * (playForm.Height + 16);
                playForm.Left = 420 + (player % 2) * (playForm.Width + 16);

                playForm.Show();
            }
        }

        private void playerCountUpDown_ValueChanged(object sender, EventArgs e)
        {
            int numberOfPlayers = (int)playerCountUpDown.Value;

            foreach (TextBox playerTextBox in playerTextBoxes)
            {
                bool shouldDisplay = playerTextBoxes.IndexOf(playerTextBox) < numberOfPlayers;
                playerTextBox.Visible = shouldDisplay;
            }
        }

        void handlePlayerJoined(object sender, EventArgs e)
        {

        }

        public void handlePlayerScored(int playerIndex, int points)
        {
            // Extract score from the player's textbox
            int score = getScore(playerTextBoxes[playerIndex].Text);

            // Add any points gained to score
            score += points;

            // Extract the "name-colon" substring from the player's textbox
            string resetText = getResetText(playerTextBoxes[playerIndex].Text);

            // Set the player's text box to be "name-colon-score"
            playerTextBoxes[playerIndex].Text = resetText + score.ToString();
        }

        private int getScore(string text)
        {
            int score = 0;

            int splitIndex = text.IndexOf(':');
            string scoreText = text.Substring(splitIndex + 1);
            score = int.Parse(scoreText);

            return score;
        }

        private string getResetText(string text)
        {
            string resetText = string.Empty;

            int splitIndex = text.IndexOf(':');
            resetText = text.Substring(0, splitIndex + 2);

            return resetText;
        }

        void handlePlayerFinished(object sender, EventArgs e)
        {

        }

        void handlePlayerLeft(object sender, EventArgs e)
        {
            PlayForm.FormCount--;

            if (0 == PlayForm.FormCount)
            {

            }
        }

        public void allPlayersFinished()
        {
            // unlock UI 
            newGameButton.Enabled = true;
            playerCountUpDown.Enabled = true;
            foreach (TextBox playerTextBox in playerTextBoxes)
            {
                playerTextBox.Enabled = true;
            }
        }
    }
}
