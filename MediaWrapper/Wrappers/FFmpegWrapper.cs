using MediaWrapper.Enums;
using MediaWrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaWrapper.Wrappers
{
    public class FFmpegWrapper : Wrapper
    {
        public FFmpegWrapper() : base(Executable.FFmpeg)
        {
 
        }

        internal Task<ProcessResult> RunProcess(string args, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                return Process(args);
            },
            CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }
    }
}
