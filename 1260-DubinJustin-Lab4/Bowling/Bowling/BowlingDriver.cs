///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Bowling / Bowling
//	File Name:         BowlingDriver.cs
//	Description:       Calculates the average for bowling.
//  Course:            CSCI 1260-001 – Introduction to Computer Science II
//	Author:            Justin Dubin
//	Created:           10/19/2022
//	Copyright:         Justin Dubin, 2022
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
    /// Main class of driver, allows user to calculate averages for bowling matches. Cannot calculate more than 25 games. Program ends when user specifies
    /// </summary>
    public class BowlingDriver
    {
        /// <summary>
        /// Main method of driver, allows user to calculate averages for bowling matches. Cannot calculate more than 25 games. Program ends when user specifies.
        /// User answer in string automatically adjusted to upper case, and exceptions ensure user cannot crash the program. 
        /// </summary>
        public static void Main()
        {
            string YesOrNo = "Y";
            string YorN = "Y";
            BowlingAverage DefaultBA = new BowlingAverage();                   //Creates new Bowling Average Object
            Console.WriteLine("Default Bowling Average: " + DefaultBA);        //Displays default bowling average (no scores)
            if (YesOrNo == "Y")
            {

                while (YorN == "Y")                                             //While Loop starts with Yes Answer by Default (Y)
                {
                    Console.Write("How many games were bowled? ");

                    try                                                         //Initial Try Statement tests for OverflowException, IndexOutOfRangeException, FormatException, and BowlingException
                    {
                        int numGames = Convert.ToInt32(Console.ReadLine());

                        if (numGames > 25 || numGames < 0)
                        {
                            throw new BowlingException("Number of games must be an integer between 1 and 25.");     //If statement and exception ensures user cannot enter wild amount of games, nor enter negative amount. 
                        }                                                                                           //If statement allows both of these things to be done in one place

                        int UserScore;
                        Console.WriteLine();                                                    //Blank WriteLines used for spacing throughout program

                        int[] Scores = new int[numGames];
                        for (int i = 1; i < numGames + 1; i++)
                        {
                            Console.Write("What was the score for game " + i + "? ");           //Loops amount of games user specifies
                            UserScore = Convert.ToInt32(Console.ReadLine());
                            Scores[i - 1] = UserScore;
                        }
                        try
                        {
                            BowlingAverage SecondBA = new BowlingAverage(Scores, numGames);    //Creates new BowlingAverage object
                            Console.WriteLine(SecondBA);
                        }
                        catch (BowlingException ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine(ex.Message);                                    //Bowling Exception specifically for new BowlingAverage object
                            Console.WriteLine();
                        }
                            Question:                                                        //goto keyword allows program to partially loop if user does not enter Y or N
                            Console.Write("Do you want to average more scores (Y/N)? ");     //Allows uesr to end loop if desired

                            YesOrNo = Console.ReadLine();
                            YorN = YesOrNo.ToUpper();                                        //Converts user answer to upper case letter. EX: y=Y, n=N
                            if (YorN == "N")
                            {
                                break;                                                       //break exits program, allowing goodbye message
                            }
                            if (YorN == "Y")
                            {
                                continue;                                                   //continue allows program to loop normally
                            }
                            else
                            {
                            Console.WriteLine();
                            Console.WriteLine("Must enter yes (Y) or no (N) ");
                            Console.WriteLine();
                            goto Question;                                                 //goto keyword allows program to partially loop if user does not enter Y or N
                        }
                    }
                    catch (System.OverflowException)
                    {
                        Console.WriteLine("\nInvalid integer input.\n");
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("\nInvalid integer input.\n");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nInvalid integer input.\n");
                    }

                    catch (BowlingException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);                                     //Bowling score {score} is invalid. It must be between 0 and 300.
                        Console.WriteLine();
                    }
                   

                }
                Console.WriteLine("\nGoodbye. Thank you for using this program.");       //Goodbye message for when program ends
            }
           
        }
    }
}
