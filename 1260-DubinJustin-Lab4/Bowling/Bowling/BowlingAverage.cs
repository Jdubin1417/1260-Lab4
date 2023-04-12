///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Bowling / Bowling
//	File Name:         BowlingAverage.cs
//	Description:       Calculates the average for bowling.
//	Course:            CSCI-1260
//	Author:            Katie Wilson, wilsonkl4@etsu.edu, East Tennessee State University
//	Created:           10/19/2022
//	Copyright:         Katie Wilson, 2022
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    /// <summary>
    /// Calculator for bowling average
    /// </summary>
    public class BowlingAverage
    {
        private int[] Scores;   //a collection of the bowling scores to average
        private int NumGames;   //the number of games of bowling played
        private double Average; //the average of scores

        /// <summary>
        /// Default constructor - sets attributes to default values
        /// </summary>
        public BowlingAverage()
        {
            NumGames = 0;
            Average = 0.0;
            Scores = null;
        }

        /// <summary>
        /// Parameterized constructor - sets attributes to passed in values
        /// </summary>
        /// <param name="scores">the array of bowling scores to set</param>
        /// <param name="numGames">the number of games of bowling played</param>
        /// <exception cref="BowlingException">if the number of games is larger than the number of scores in 
        /// the given array OR an individual score is not in the valid bowling range of 0 to 300 OR the number of 
        /// games is 0 or less, this exception is thrown</exception>
        public BowlingAverage(int[] scores, int numGames)
        {
            if(numGames > scores.Length)
            {
                throw new BowlingException("The number of games is less than the number of scores submitted");
            }

            foreach(int score in scores)
            {
                if(score < 0 || score > 300)
                {
                    throw new BowlingException($"Bowling score {score} is invalid. It must be between 0 and 300.");
                }
            }

            Scores = scores;

            if(numGames > 0)
            {
                NumGames = numGames;
            }
            else
            {
                throw new BowlingException("Number of games must be a postitive integer.");
            }

            CalculateAverage();
        }

        /// <summary>
        /// Calculate the average of the scores array
        /// </summary>
        private void CalculateAverage()
        {
            double sum = 0.0;

            if(NumGames > 0)
            {
                foreach(int score in Scores)
                {
                    sum += score;
                }

                Average = sum / NumGames;
            }
        }

        /// <summary>
        /// Format the BowlingAverage object for easy-to-read display
        /// </summary>
        /// <returns>a formatted string containing all of the information about the BowlingAverage</returns>
        public override string ToString()
        {
            string info = "\nFor the following scores:\n\n";

            if(Scores != null)
            {
                foreach(int score in Scores)
                {
                    info += $"\t\t{score}\n";
                }
                info += "------------------------------\n";
                info += $"The average is {Average, 0:0.00}\n";
            }
            else
            {
                info = "There are no scores to average.\n";
            }

            return info;
        }
    }
}
