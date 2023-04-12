///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Bowling / Bowling
//	File Name:         BowlingException.cs
//	Description:       Specialized exception class to define a bowling exception with its unique message.
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
    /// Specialized exception class to define a bowling exception with its unique message.
    /// </summary>
    public class BowlingException : Exception
    {
        /// <summary>
        /// The default constructor - calls Exception's default constructor
        /// </summary>
        public BowlingException() : base() { }

        /// <summary>
        /// The parameterized constructor - calls Exception's parameterized constructor
        /// </summary>
        /// <param name="message">the message to display when the exception occurs</param>
        public BowlingException(string message) : base(message) { }

        /// <summary>
        /// The parameterized constructor - calls Exception's parameterized constructor
        /// </summary>
        /// <param name="message">the message to display when the exception occurs</param>
        /// <param name="e">the exception itself</param>
        public BowlingException(string message, Exception e) : base(message, e) { }

        /// <summary>
        /// Makes it so that when you display a BowlingException's exception Message (e.g., e.Message), it displays
        /// the text "Bowling Average Exception" followed by whatever the message is set to be when the exception
        /// was created.
        /// </summary>
        public override string Message => "Bowling Average Exception: " + base.Message;
    }
}
