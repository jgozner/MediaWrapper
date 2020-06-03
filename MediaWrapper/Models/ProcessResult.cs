using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Models
{
    public class ProcessResult
    {
        public string Output { get; internal set; }
        public string Error { get; internal set; }
        public int ExitCode { get; internal set; }
    }
}
