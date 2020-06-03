using MediaWrapper.Enums;
using MediaWrapper.Exceptions;
using MediaWrapper.Helpers;
using MediaWrapper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaWrapper.Wrappers
{
    [ExcludeFromCodeCoverage]
    public abstract class Wrapper
    {
        /// <summary>
        ///  Directory containing executables.
        /// </summary>
        public static string ExecutablesPath { get; set; }

        /// <summary>
        /// Executable Process Id.
        /// </summary>
        public int ProcessId { get; private set; }

        /// <summary>
        /// Process Priority.
        /// </summary>
        public ProcessPriorityClass? Priority { get; set; }

        protected string ExecutableFilePath
        {
            get
            {
                lock (_infoPathLock)
                {
                    return _executableFilePath;
                }
            }
            set
            {
                lock (_infoPathLock)
                {
                    _executableFilePath = value;
                }
            }
        }

        private string _executableFilePath;
        private readonly object _infoPathLock = new object();


        public Wrapper(Executable executable)
        {
            if (!string.IsNullOrWhiteSpace(ExecutableFilePath))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(ExecutablesPath))
            {
                ExecutableFilePath = ExecutableHelper.SelectExecutableFromPath(executable, ExecutablesPath);

                if (!string.IsNullOrEmpty(ExecutableFilePath))
                {
                    return;
                }
            }

            Assembly entryAssembly = Assembly.GetEntryAssembly();

            if (entryAssembly != null)
            {
                string workingDirectory = Path.GetDirectoryName(entryAssembly.Location);

                ExecutableFilePath = ExecutableHelper.SelectExecutableFromPath(executable, workingDirectory);

                if (ExecutableFilePath != null)
                {
                    return;
                }
            }

            string[] paths = Environment.GetEnvironmentVariable("PATH")
                              .Split(Path.PathSeparator);

            foreach (string path in paths)
            {
                ExecutableFilePath = ExecutableHelper.SelectExecutableFromPath(executable, path);

                if (ExecutableFilePath != null)
                {
                    return;
                }
            }

            throw new ExecutableNotFoundException($"Could not find {executable.Name}. Please add it to your PATH variable or path to DIRECTORY with FFmpeg executables in {nameof(Wrapper)}.{nameof(ExecutablesPath)}");

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="processPath"></param>
        protected ProcessResult Process(string args)
        {

            using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
            using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = ExecutableFilePath;
                    process.StartInfo.Arguments = args;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardInput = false;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.EnableRaisingEvents = true;

                    StringBuilder output = new StringBuilder();
                    StringBuilder error = new StringBuilder();

                    var result = new ProcessResult();

                    process.OutputDataReceived += (sender, e) => {
                        if (e.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            output.AppendLine(e.Data);
                        }
                    };
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            error.AppendLine(e.Data);
                        }
                    };
                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();

                    result.Output = output.ToString();
                    result.Error = error.ToString();

                    return result;
                }
            }
            

        }

    }
}
