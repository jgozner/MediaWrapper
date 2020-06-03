using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Helpers
{
    internal static class FileHelper
    {
        public static bool CompareFileNames(string fileName, string expectedName)
        {
            return fileName.Equals(expectedName, StringComparison.InvariantCultureIgnoreCase)
                   || fileName.Equals($"{expectedName}.exe", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
