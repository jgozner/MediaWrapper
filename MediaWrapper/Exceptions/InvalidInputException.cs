using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaWrapper.Exceptions
{
    public class InvalidInputException : Exception
    {
        /// <summary>
        ///     The exception that is thrown when input is invalid.
        /// </summary>
        /// <param name="msg"></param>
        public InvalidInputException(string msg) : base(msg)
        {
        }
    }
}
