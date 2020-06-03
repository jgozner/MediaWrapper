using MKVToolkit.Tracks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaWrapper.Interfaces
{
    /// <summary>
    /// Information about the media file
    /// </summary>
    public interface IMediaInfo
    {
        /// <summary>
        ///     Source file info
        /// </summary>
        FileInfo FileInfo { get; }

        /// <summary>
        /// Video tracks
        /// </summary>
        IEnumerable<IVideoTrack> VideoTracks { get; }

        /// <summary>
        /// Audio tracks
        /// </summary>
        IEnumerable<IAudioTrack> AudioTracks { get; }

        /// <summary>
        /// Subtitle tracks
        /// </summary>
        IEnumerable<ISubtitleTrack> SubtitleTracks { get; }
    }
}
