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

            do
            {
                PlayForm playForm = new PlayForm(this);
                Show(playForm);
                PlayForm.FormCount++;
            }
            while (PlayForm.FormCount < numberOfPlayers);
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
    }
}
