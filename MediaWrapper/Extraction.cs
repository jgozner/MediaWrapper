using MediaWrapper.Enums;
using MediaWrapper.Exceptions;
using MediaWrapper.Helpers;
using MediaWrapper.Interfaces;
using MediaWrapper.Models;
using MediaWrapper.Tracks;
using MediaWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaWrapper
{
    public class Extraction : IExtraction
    {
        private readonly object _builderLock = new object();

        private readonly List<ITrack> _tracks = new List<ITrack>();

        private FFmpegWrapper _wrapper;
        private string _outputDirectory;

        /// <summary>
        /// Grab a new instance of Extractor
        /// </summary>
        /// <returns></returns>
        public static IExtraction New()
        {
            return new Extraction();
        }

        public Task<IExtractionResult> Start()
        {
            return Start(Build());
        }

        public Task<IExtractionResult> Start(string parameters)
        {
            return Start(parameters, new CancellationToken());
        }

        public string Build()
        {
            lock (_builderLock)
            {
                var builder = new StringBuilder();

                builder.Append(BuildInput()).Append(" ");
                builder.Append(BuildParameters());
                
                return builder.ToString();
            }
        }

        public async Task<IExtractionResult> Start(string parameters, CancellationToken cancellationToken)
        {
            if(_wrapper != null)
            {
                throw new InvalidOperationException("Must create another Extraction resource, cannot reuse.");
            }

            _wrapper = new FFmpegWrapper();

            var result = new ExtractResult
            {
                StartTime = DateTimeOffset.UtcNow,
                Arguments = parameters,
                Tracks = _tracks,
                Success = true
            };

            var processResult = await _wrapper.RunProcess(parameters, cancellationToken).ConfigureAwait(false);

            if(processResult.ExitCode != 0 || processResult.Output.ToLower().Contains("error"))
            {
                result.Success = false;
                result.Error = processResult.Output;
            }
            result.EndTime = DateTimeOffset.UtcNow;

            return result;
        }

        private string BuildInput()
        {
            var builder = new StringBuilder();

            List<string> inputs = _tracks.Select(x => x.FileInfo.FullName).Distinct().ToList();

            if(inputs.Count > 1)
            {
                throw new InvalidInputException("All tracks must be from the same source");
            }

            if(inputs.Count == 0)
            {
                throw new InvalidInputException("Extraction contains no input.");
            }

            builder.Append($"-i {inputs[0]}");

            return builder.ToString();
        }

        private string BuildParameters()
        {
            var builder = new StringBuilder();

            foreach(ITrack track in _tracks)
            {
                var directory = _outputDirectory ?? Path.GetTempPath();
                var fileName = Guid.NewGuid();
                var extension = track.GetExtension();

                var file = Path.Combine(directory, fileName + "." + extension.Name);
                track.FileInfo = new FileInfo(file);

                builder.Append($"-map 0:{track.StreamOrder} -c copy {file}").Append(" ");
            }

            return builder.ToString();
        }


        public IExtraction AddTrack<T>(params T[] tracks) where T : ITrack
        {
            foreach (var track in tracks)
            {
                if(track != null)
                {
                    _tracks.Add(track);
                }
            }
            return this;
        }

        public IExtraction SetOutputDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new InvalidInputException($"Specified directory:{directory} does not exist or we are unable to access it");
            }
            _outputDirectory = directory;
            return this;
        }

        


    }
}
