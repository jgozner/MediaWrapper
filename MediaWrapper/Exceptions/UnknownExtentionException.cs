using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Exceptions
{
    public class UnkownExtentionException : InvalidInputException
    {
        /// <summary>
        ///     The exception that is thrown when the extension is not known.
        /// </summary>
        /// <param name="msg"></param>
        public UnkownExtentionException(string msg) : base(msg)
        {
        }
    }
}
