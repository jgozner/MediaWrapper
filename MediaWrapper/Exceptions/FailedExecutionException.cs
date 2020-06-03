using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace MediaWrapper.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class FailedExecutionException : FileNotFoundException
    {
        internal FailedExecutionException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
