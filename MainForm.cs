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
        private List<Button> playerColorButtons;

        public MainForm()
        {
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            playerTextBoxes = new List<TextBox> { playerOneTextBox, playerTwoTextBox, playerThreeTextBox, playerFourTextBox };
            playerColorButtons = new List<Button> { p1ColorButton, p2ColorButton, p3ColorButton, p4ColorButton };

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
                // Create a new PlayForm and set Text and Backcolor properties
                PlayForm playForm = new PlayForm(this, player);
                playForm.Text = playerTextBoxes[player].Text;
                
                // set PlayForm backcolor

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

            //foreach (TextBox playerTextBox in playerTextBoxes)
            //{
            //    bool shouldDisplay = playerTextBoxes.IndexOf(playerTextBox) < numberOfPlayers;
            //    playerTextBox.Visible = shouldDisplay;
            //}
            //foreach (Button playerColorButton in playerColorButtons)
            //{
                
            //}
            for (int i = 0; i < 4; i++)
            {
                bool shouldDisplay = i < numberOfPlayers;
                playerTextBoxes[i].Visible = shouldDisplay;
                playerColorButtons[i].Visible = shouldDisplay;
            }
        }

        public void handlePlayerScored(int playerIndex, int totalPoints)
        {
            // Extract the "name-colon" substring from the player's textbox
            string resetText = getResetText(playerTextBoxes[playerIndex].Text);

            string nameScoreText = resetText + totalPoints.ToString();

            // Set the player's textbox text to be "name-colon-score"
            playerTextBoxes[playerIndex].Text = nameScoreText;

            // Check player's score against top score
            checkForTopScore(playerIndex, totalPoints);
        }

        private void checkForTopScore(int playerIndex, int playerScore)
        {
            int topScore = getScore(topScoreIndicatorLabel.Text);

            if (playerScore > topScore)
            {
                string nameScoreText = getPlayerName(playerIndex) + ": " + playerScore.ToString();
                topScoreIndicatorLabel.Text = nameScoreText;
            }
        }

        public void checkForHighScore(int playerIndex, int playerScore)
        {
            int highScore = getScore(highScoreIndicatorLabel.Text);

            if (playerScore > highScore)
            {
                string nameScoreText = getPlayerName(playerIndex) + ": " + playerScore.ToString();
                highScoreIndicatorLabel.Text = nameScoreText;
            }
        }

        private string getResetText(string text)
        {
            string resetText = string.Empty;

            int splitIndex = text.IndexOf(':');
            resetText = text.Substring(0, splitIndex + 2);

            return resetText;
        }

        private int getScore(string text)
        {
            int score = 0;

            int splitIndex = text.IndexOf(':');
            string scoreText = text.Substring(splitIndex + 2);
            score = int.Parse(scoreText);

            return score;
        }

        private string getPlayerName(int playerIndex)
        {
            string name = string.Empty;

            string text = playerTextBoxes[playerIndex].Text;
            int splitIndex = text.IndexOf(':');
            name = text.Substring(0, splitIndex);

            return name;
        }

        public void checkForRemainingPlayers()
        {
            if (PlayForm.FormCount == 0)
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

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int buttonTag = int.Parse(button.Tag.ToString());
            Console.WriteLine(buttonTag);
        }

    }
}
