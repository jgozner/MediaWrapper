using MediaWrapper.Enums;
using MediaWrapper.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKVToolkit.Tracks
{
    public interface IAudioTrack : ITrack
    {
        string Format { get; set; }
        double Duration { get; set; }
        int Bitrate { get; set; }
        int SamplingRate { get; set; }
        int SamplingCount { get; set; }
        string CompressionMode { get; set; }
        string Language { get; set; }
    }
}
