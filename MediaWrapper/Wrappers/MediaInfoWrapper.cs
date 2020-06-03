using MediaWrapper.Enums;
using MediaWrapper.Exceptions;
using MediaWrapper.Helpers;
using MediaWrapper.Models;
using MKVToolkit.Tracks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaWrapper.Wrappers
{
    internal class MediaInfoWrapper : Wrapper
    {

        public MediaInfoWrapper() : base(Executable.MediaInfo)
        {
        }


        public async Task<MediaInfo> GetProperties(FileInfo fileInfo, MediaInfo mediaInfo)
        {
            TrackInfoOutput[] tracks = await GetTracks(fileInfo.FullName).ConfigureAwait(false);

            if (!tracks.Any())
            {
                throw new ArgumentException($"Invalid file. Cannot load file {fileInfo.Name}");
            }

            mediaInfo.VideoTracks = PrepareVideoTracks(fileInfo, tracks.Where(x => x.Type.ToLower() == "video"));
            mediaInfo.AudioTracks = PrepareAudioTracks(fileInfo, tracks.Where(x => x.Type.ToLower() == "audio"));
            mediaInfo.SubtitleTracks = PrepareSubtitleTracks(fileInfo, tracks.Where(x => x.Type.ToLower() == "text"));

            return mediaInfo;
        }

        private async Task<TrackInfoOutput[]> GetTracks(string filePath)
        {
            MediaInfoOutput info = null;

            ProcessResult result = await RunProcess($"\"{filePath}\" --output=JSON").ConfigureAwait(false);

            if (string.IsNullOrEmpty(result.Output))
            {
                return new TrackInfoOutput[0];
            }

            info = JsonConvert.DeserializeObject<MediaInfoOutput>(result.Output);

            return info.Media.Track ?? new TrackInfoOutput[0];
        }

        private Task<ProcessResult> RunProcess(string args)
        {
            return Task.Factory.StartNew(() =>
            {
                return Process(args);
            },
            CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private IEnumerable<IVideoTrack> PrepareVideoTracks(FileInfo fileInfo, IEnumerable<TrackInfoOutput> trackModels)
        {
            foreach (var model in trackModels)
            {
                var track = new VideoTrack
                {
                    ID = model.ID,
                    FileInfo = fileInfo,
                    StreamOrder = model.StreamOrder,
                    Format = model.Format,
                    FormatProfile = model.Format_Profile,
                    FormatLevel = model.Format_Level,
                    Width = model.Width,
                    Height = model.Height,
                    CodecId = model.CodecID,
                    Duration = model.Duration,
                    Bitrate = model.Bitrate,
                    PixelAspectRatio = model.PixelAspectRatio,
                    DisplayAspectRatio = model.DisplayAspectRatio,
                    FrameRateMode = model.FrameRate_Mode,
                    FrameRate = model.FrameRate,
                    ColorSpace = model.ColorSpace,
                    ChromaSubSampling = model.ChromaSubSampling,
                    BitDepth = model.BitDepth,
                    EncodedLibrarySetteings = model.Encoded_Library_Settings
                };
                yield return track;
            }
        }

        private IEnumerable<IAudioTrack> PrepareAudioTracks(FileInfo fileInfo, IEnumerable<TrackInfoOutput> trackModels)
        {
            foreach (var model in trackModels)
            {
                var track = new AudioTrack
                {
                    ID = model.ID,
                    FileInfo = fileInfo,
                    StreamOrder = model.StreamOrder,
                    CodecId = model.CodecID,
                    Format = model.Format,
                    Duration = model.Duration,
                    Language = model.Language,
                    Bitrate = model.Bitrate,
                    SamplingRate = model.SamplingRate,
                    SamplingCount = model.SamplingCount,
                    CompressionMode = model.Compression_Mode
                };

                yield return track;
            }
        }

        private IEnumerable<ISubtitleTrack> PrepareSubtitleTracks(FileInfo fileInfo, IEnumerable<TrackInfoOutput> trackModels)
        {
            foreach (var model in trackModels)
            {
                var track = new SubtitleTrack
                {
                    ID = model.ID,
                    FileInfo = fileInfo,
                    StreamOrder = model.StreamOrder,
                    Format = model.Format,
                    CodecId = model.CodecID,
                    Duration = model.Duration,
                    Bitrate = model.Bitrate,
                    Language = model.Language
                };
                yield return track;
            }
        }


    }
}
