﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Moon_Asg6_Yahtzee_Multiplayer
{
    internal class Hand
    {

        private Die[] dice;
        private ImageList dieImages;

        private int rollsRemaining = -1;
        private int roundsRemaining = -1;

        public int RollsRemaining { get => rollsRemaining; }
        public int RoundsRemaining { get => roundsRemaining; }

        public Hand(ImageList dieImages) {
            this.dieImages = dieImages;

            // Instantiate 5 new Dice objects and populate the dice array with them
            dice = new Die[5];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die(dieImages);
            }
        }

        /// <summary>
        /// Rolls any dice not marked as 'held'.
        /// </summary>
        /// <param name="diceToRoll">A bool array indicating which dice to roll. (true -> roll)</param>
        public void rollDice(bool[] diceToRoll)
        {
            // Iterate through the dice to roll, and roll the die at that index if it should be rolled
            for (int i = 0; i < diceToRoll.Length; i++)
            {
                if (diceToRoll[i])
                    dice[i].rollDie();
            }
            rollsRemaining -= 1;
        }

        /// <summary>
        /// Resets remaining rounds to 13, standard for a 'new game' in Yahtzee
        /// </summary>
        public void resetRoundsRemaining()
        {
            roundsRemaining = 13;
        }

        /// <summary>
        /// New round "clean-up" method; Resets remaining rolls, remaining rounds, and dice.
        /// </summary>
        public void startNewRound()
        {
            rollsRemaining = 3;
            roundsRemaining -= 1;

            foreach (Die die in dice)
            {
                die.resetDie();
            }
        }

        /// <summary>
        /// Gets an int array representing the values currently displayed on the dice.
        /// </summary>
        /// <returns>An array representing the dice values.</returns>
        public int[] getDieValues()
        {
            //var dieValues = Enumerable.Range(0, 5).Select(n => dice[n].Value).ToArray();
            int[] dieValues = new int[5];
            for (int i = 0; i < dieValues.Length; i++)
                dieValues[i] = dice[i].Value;

            return dieValues;
        }

        /// <summary>
        /// Gets an Image array containing the Images of each Die in the Hand.
        /// </summary>
        /// <returns>An array of Images of the dice.</returns>
        public Image[] getDieImages()
        {
            Image[] dieImages = new Image[5];
            for (int i = 0; i < dice.Length; i++)
            {
                dieImages[i] = dice[i].DieImage;
            }
            return dieImages;
        }

        

    }
}
