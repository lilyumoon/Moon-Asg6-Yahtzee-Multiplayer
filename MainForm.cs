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

            for (int player = 0; player < numberOfPlayers; player++)
            {
                PlayForm playForm = new PlayForm(this);
                playForm.Text = playerTextBoxes[player].Text;

                playForm.StartPosition = FormStartPosition.Manual;
                playForm.Top = 16 + (int)Math.Floor((decimal)player / 2) * (playForm.Height + 16);
                playForm.Left = 420 + (player % 2) * (playForm.Width + 16);
                playForm.Show();

                PlayForm.FormCount++;
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
    }
}
