using MediaWrapper.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Interfaces
{
    /// <summary>
    /// Information about the extraction
    /// </summary>
    public interface IExtractionResult
    {
        /// <summary>
        /// Result of extract
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Date and time of starting extract
        /// </summary>
        DateTimeOffset StartTime { get; }

        /// <summary>
        /// Date and time of ending extract
        /// </summary>
        DateTimeOffset EndTime { get; }

        /// <summary>
        /// Arguments passed to MKVExtract
        /// </summary>
        string Arguments { get; }

        /// <summary>
        /// Tracks that were extracted
        /// </summary>
        List<ITrack> Tracks { get; }

        /// <summary>
        /// 
        /// </summary>
        string Error { get; }


    }
}
