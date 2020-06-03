using MediaWrapper.Enums;
using MediaWrapper.Exceptions;
using MediaWrapper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaWrapper.Helpers
{
    internal static class ExecutableHelper
    {
        internal static string SelectExecutableFromPath(Executable executable, string directory)
        {
            if (!Directory.Exists(directory))
            {
                return null;
            }

            IEnumerable<FileProperty> files = new DirectoryInfo(directory).GetFiles().Select(x => new Models.FileProperty
            {
                Name = x.Name,
                FullName = x.FullName
            });

            return files.FirstOrDefault(x => FileHelper.CompareFileNames(x.Name, executable.Name))
                                    ?.FullName;
        }

    }
}
