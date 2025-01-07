using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moon_Asg6_Yahtzee_Multiplayer
    {
    internal class Score
    {

        public Score()
        {

        }

        public int scoreOnes(int[] diceValues)
        {
            return scoreUpper(diceValues, 1);
        }

        public int scoreTwos(int[] diceValues)
        {
            return scoreUpper(diceValues, 2);
        }

        public int scoreThrees(int[] diceValues)
        {
            return scoreUpper(diceValues, 3);
        }

        public int scoreFours(int[] diceValues)
        {
            return scoreUpper(diceValues, 4);
        }

        public int scoreFives(int[] diceValues)
        {
            return scoreUpper(diceValues, 5);
        }

        public int scoreSixes(int[] diceValues)
        {
            return scoreUpper(diceValues, 6);
        }

        /// <summary>
        /// Iterates through the diceValues, compares each dieValue to value, and increments points by value if match.
        /// </summary>
        /// <param name="diceValues">The array of dice to score.</param>
        /// <param name="value">The value to match the dice to.</param>
        /// <returns>The number of points scored.</returns>
        private int scoreUpper(int[] diceValues, int value)
        {
            int points = 0;

            foreach (int i in diceValues)
            {
                if (value == i)
                    points += value;
            }

            return points;
        }

        public int scoreThreeOfAKind(int[] diceValues)
        {
            int points = 0;
            bool hasThreeOfAKind = false;

            int[] numberOfEachDice = getQuantityOfEachDie(diceValues);

            foreach (int quantity in numberOfEachDice)
            {
                if (quantity >= 3)
                    hasThreeOfAKind = true;
            }

            if (hasThreeOfAKind)
                points = getSumOfAllDice(diceValues);

            return points;
        }

        public int scoreFourOfAKind(int[] diceValues)
        {
            int points = 0;
            bool hasFourOfAKind = false;

            int[] numberOfEachDice = getQuantityOfEachDie(diceValues);

            foreach (int quantity in numberOfEachDice)
            {
                if (quantity >= 4)
                    hasFourOfAKind = true;
            }

            if (hasFourOfAKind)
                points = getSumOfAllDice(diceValues);

            return points;
        }

        public int scoreFullHouse(int[] diceValues)
        {
            int points = 0;
            int[] numberOfEachDice = getQuantityOfEachDie(diceValues);

            bool hasThreeOfAKind = false;
            bool hasTwoOfAKind = false;

            // If there are 3 of one kind and 2 of another kind, it's a full house
            foreach (int quantity in numberOfEachDice)
            {
                if (quantity == 3)
                    hasThreeOfAKind = true;
            }

            // Only check if there is a pair if there is already 3 of a kind
            if (hasThreeOfAKind)
            {
                foreach (int quantity in numberOfEachDice)
                {
                    if (quantity == 2)
                        hasTwoOfAKind = true;
                }
            }

            if (hasThreeOfAKind && hasTwoOfAKind)
                points += 25;

            return points;
        }

        public int scoreSmallStraight(int[] diceValues)
        {
            int points = 0;
            bool isSmallStraight = false;

            // Define small straight patterns
            int[] lowerSmallStraight = { 1, 2, 3, 4 };
            int[] middleSmallStraight = { 2, 3, 4, 5 };
            int[] upperSmallStraight = { 3, 4, 5, 6 };
            int[][] matchingPatterns = { lowerSmallStraight, middleSmallStraight, upperSmallStraight };

            // Ignore duplicate dice and arrange the values in ascending order
            int[] sortedUniqueDiceValues = diceValues.Distinct().OrderBy(x => x).ToArray();

            // Check if any small straight pattern is a subset of sorted dice values
            foreach (int[] pattern in matchingPatterns)
            {
                bool isMatch = true;
                
                foreach (int number in pattern)
                {
                    if (!sortedUniqueDiceValues.Contains(number))
                    {
                        isMatch = false;
                        break;
                    }
                }

                // If any pattern is a subset of sorted dice values, it's a small straight
                if (isMatch)
                    isSmallStraight = true;
            }

            if (isSmallStraight)
                points += 30;

            return points;
        }

        public int scoreLargeStraight(int[] diceValues)
        {
            int points = 0;
            bool isLargeStraight = false;

            // Define large straight patterns
            int[] lowerLargeStraight = { 1, 2, 3, 4, 5 };
            int[] upperLargeStraight = { 2, 3, 4, 5, 6 };
            int[][] matchingPatterns = { lowerLargeStraight, upperLargeStraight };

            // Ignore duplicate dice and arrange the values in ascending order
            int[] sortedUniqueDiceValues = diceValues.Distinct().OrderBy(x => x).ToArray();

            // Check if any large straight pattern matches the sorted dice values
            if (lowerLargeStraight.SequenceEqual(sortedUniqueDiceValues) ||
                upperLargeStraight.SequenceEqual(sortedUniqueDiceValues))
            {
                isLargeStraight = true;
            }

            if (isLargeStraight)
                points += 40;

            return points;
        }

        public int scoreYahtzee(int[] diceValues)
        {
            int points = 0;
            bool isYahtzee = false;

            int[] numberOfEachDice = getQuantityOfEachDie(diceValues);

            // If there are 5 of any one die value, it's a Yahtzee
            foreach (int quantity in numberOfEachDice)
            {
                if (quantity == 5)
                    isYahtzee = true;
            }

            if (isYahtzee)
                points += 50;

            return points;
        }

        public int scoreChance(int[] diceValues)
        {
            int points = 0;

            points += getSumOfAllDice(diceValues); 

            return points;
        }

        private int[] getQuantityOfEachDie(int[] diceValues)
        {
            // Create an array to map potential die values to
            // the number of current dice which match that value
            int[] quantityOfEachDice = new int[6];

            // Iterate through each potential value of a die (1-6)
            for (int i = 1; i < 7; i++)
            {
                int count = 0;
                foreach (int dieValue in diceValues)
                {
                    // If the die value matches, increment count
                    if (dieValue == i)
                        count++;
                }

                // Store the quantity of dice that match the value of the current iteration
                quantityOfEachDice[i - 1] = count;
            }

            return quantityOfEachDice;
        }

        private int getSumOfAllDice(int[] diceValues)
        {
            int sum = 0;

            foreach (int dieValue in diceValues)
            {
                sum += dieValue;
            }

            return sum;
        }

    }
}
