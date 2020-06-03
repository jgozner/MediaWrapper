using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace MediaWrapper.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ExecutableNotFoundException : FileNotFoundException
    {
        internal ExecutableNotFoundException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
