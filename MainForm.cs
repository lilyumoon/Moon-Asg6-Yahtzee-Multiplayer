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
            // minor housekeeping
            playerTextBoxes = new List<TextBox> { playerOneTextBox, playerTwoTextBox, playerThreeTextBox, playerFourTextBox };
            playerColorButtons = new List<Button> { p1ColorButton, p2ColorButton, p3ColorButton, p4ColorButton };

            // set this form's position
            this.StartPosition = FormStartPosition.Manual;
            this.Top = 16;
            this.Left = 16;
        }

        /// <summary>
        /// Event handler for the 'new game' button's Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameButton_Click(object sender, EventArgs e)
        {
            lockUI();
            startNewGame();
        }

        /// <summary>
        ///  Opens a personalized yahtzee instance for each player joining the game.
        /// </summary>
        private void startNewGame()
        {
            int numberOfPlayers = (int)playerCountUpDown.Value;

            // open one playForm per player
            for (int playerIndex = 0; playerIndex < numberOfPlayers; playerIndex++)
            {
                // Create a new PlayForm and set Text
                PlayForm playForm = new PlayForm(this, playerIndex);
                playForm.Text = playerTextBoxes[playerIndex].Text;

                // set PlayForm backcolor
                playForm.BackColor = playerTextBoxes[playerIndex].BackColor;

                // set position of PlayForm
                playForm.StartPosition = FormStartPosition.Manual;
                playForm.Top = 16 + (int)Math.Floor((decimal)playerIndex / 2) * (playForm.Height + 16);
                playForm.Left = 420 + (playerIndex % 2) * (playForm.Width + 16);

                playForm.Show();
            }

            // initialize all scores to 0
            for (int i = 0; i < 4; i++)
            {
                playerTextBoxes[i].Text += ": 0";
            }
        }

        /// <summary>
        /// Sets the form's UI to a 'game in progress' state
        /// </summary>
        private void lockUI()
        {
            // lock UI 
            newGameButton.Enabled = false;
            playerCountUpDown.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                playerTextBoxes[i].Enabled = false;
                playerColorButtons[i].Enabled = false;
            }
        }

        private void playerCountUpDown_ValueChanged(object sender, EventArgs e)
        {
            updatePlayerDisplay((NumericUpDown)sender);
        }

        /// <summary>
        /// Updates which players are displayed to reflect the value in playerCountControl.
        /// </summary>
        /// <param name="playerCountControl">The NumericUpDown control that determines the number of players.</param>
        private void updatePlayerDisplay(NumericUpDown playerCountControl)
        {
            int numberOfPlayers = (int)playerCountControl.Value;

            for (int i = 0; i < 4; i++)
            {
                bool shouldDisplay = i < numberOfPlayers;
                playerTextBoxes[i].Visible = shouldDisplay;
                playerColorButtons[i].Visible = shouldDisplay;
            }
        }

        public void handlePlayerScored(int playerIndex, int totalPoints)
        {
            string playerName = getPlayerName(playerIndex);
            string nameScorePair = $"{playerName}: {totalPoints}";

            // Update the player's textbox text
            playerTextBoxes[playerIndex].Text = nameScorePair;

            // Check player's score against the top score
            checkForTopScore(playerIndex, totalPoints);
        }

        // TODO: could refactor these to reduce repetition...

        /// <summary>
        /// Checks if a player's score has become the top score of the game, and if so, updates UI to reflect the change.
        /// </summary>
        /// <param name="playerIndex">The index of the player to check.</param>
        /// <param name="playerScore">The score of the player to check.</param>
        private void checkForTopScore(int playerIndex, int playerScore)
        {
            int topScore = getScore(topScoreIndicatorLabel.Text);

            if (playerScore > topScore)
            {
                string playerName = getPlayerName(playerIndex);
                string nameScorePair = $"{playerName}: {playerScore}";

                topScoreIndicatorLabel.Text = nameScorePair;
            }
        }

        /// <summary>
        /// Checks if a player's score has become the high score (all-time top score), and if so, updates UI to reflect the change.
        /// Called when a game is 'completed'
        /// </summary>
        /// <param name="playerIndex">The index of hte player to check.</param>
        /// <param name="playerScore">The score of the player to check.</param>
        public void checkForHighScore(int playerIndex, int playerScore)
        {
            int highScore = getScore(highScoreIndicatorLabel.Text);

            if (playerScore > highScore)
            {
                string playerName = getPlayerName(playerIndex);
                string nameScorePair = $"{playerName}: {playerScore}";

                highScoreIndicatorLabel.Text = nameScorePair;
            }
        }

        /// <summary>
        /// Gets the score of a specified player.
        /// </summary>
        /// <param name="nameScorePair">The text from which to extract the score. Format: "{name}: {score}</param>
        /// <returns>The player's score.</returns>
        private int getScore(string nameScorePair)
        {
            int score = 0;

            int splitIndex = nameScorePair.IndexOf(':');
            string scoreText = nameScorePair.Substring(splitIndex + 2);
            score = int.Parse(scoreText);

            return score;
        }

        /// <summary>
        /// Gets the raw text of a specified player's name.
        /// </summary>
        /// <param name="playerIndex">The index of the player whose name should be returned.</param>
        /// <returns>The name of the player at playerIndex.</returns>
        private string getPlayerName(int playerIndex)
        {
            string name = string.Empty;

            string text = playerTextBoxes[playerIndex].Text;
            int splitIndex = text.IndexOf(':');
            name = text.Substring(0, splitIndex);

            return name;
        }

        /// <summary>
        /// Handler for PlayForm's FormClosing event. If the last form is closing, resets player names and unlocks UI.
        /// </summary>
        public void checkForRemainingPlayers()
        {
            if (PlayForm.FormCount == 0)
            {
                // reset player names
                for (int playerIndex = 0; playerIndex < 4; playerIndex++)
                {
                    playerTextBoxes[playerIndex].Text = getPlayerName(playerIndex);
                }

                unlockUI();
            }
        }

        /// <summary>
        /// Sets this form's UI to a 'game not in progress' state
        /// </summary>
        private void unlockUI()
        {
            newGameButton.Enabled = true;
            playerCountUpDown.Enabled = true;
            for (int playerIndex = 0; playerIndex < 4; playerIndex++)
            {
                playerTextBoxes[playerIndex].Enabled = true;
                playerColorButtons[playerIndex].Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for all player color buttons' Click events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            colorMethod((Button)sender);
        }

        /// <summary>
        /// Opens a color dialogue window, waits for a selection, and applies the selected color to the relevant player.
        /// </summary>
        /// <param name="colorPickerButton">The color picker button which was pressed.</param>
        private void colorMethod(Button colorPickerButton)
        {
            // Find the relevant player index
            int playerIndex = playerColorButtons.IndexOf(colorPickerButton);

            // Set the initial selection of the color dialog if possible
            colorDialog.Color = playerTextBoxes[playerIndex].BackColor;

            // Show color dialog and wait for user to choose
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the relevant player textbox and color picker button background colors
                playerColorButtons[playerIndex].BackColor = colorDialog.Color;
                playerTextBoxes[playerIndex].BackColor = colorDialog.Color;
            }
            // (the color picker dialog is closed here)

        }

    }
}
