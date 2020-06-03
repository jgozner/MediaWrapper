using MediaWrapper.Interfaces;
using MediaWrapper.Wrappers;
using MKVToolkit.Tracks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MediaWrapper
{
    public sealed class MediaInfo : IMediaInfo
    {

        public FileInfo FileInfo { get;}
        public IEnumerable<IVideoTrack> VideoTracks { get; internal set; }
        public IEnumerable<IAudioTrack> AudioTracks { get; internal set; }
        public IEnumerable<ISubtitleTrack> SubtitleTracks { get; internal set; }

        public MediaInfo(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        /// <summary>
        /// Get MediaInfo from a local file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Task<IMediaInfo> Get(string filePath)
        {
            return Get(new FileInfo(filePath));
        }

        /// <summary>
        /// Get MediaInfo from a remote file
        /// </summary>
        /// <param name="fileUri"></param>
        /// <returns></returns>
        public static Task<IMediaInfo> Get(Uri fileUri)
        {
            return Get(new FileInfo(fileUri.AbsolutePath));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        private async static Task<IMediaInfo> Get(FileInfo fileInfo)
        {
            var mediaInfo = new MediaInfo(fileInfo);
            mediaInfo = await new MediaInfoWrapper().GetProperties(fileInfo, mediaInfo);
            return mediaInfo;
        }

    }
}
