using MediaWrapper.Interfaces;
using MediaWrapper.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Models
{
    public class ExtractResult : IExtractionResult
    {
        public bool Success { get; internal set; }

        public DateTimeOffset StartTime { get; internal set; }

        public DateTimeOffset EndTime { get; internal set; }

        public string Arguments { get; internal set; }

        public List<ITrack> Tracks { get; internal set; }

        public string Error { get; internal set; }
    }
}
