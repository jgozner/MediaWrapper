using MediaWrapper.Enums;
using MediaWrapper.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKVToolkit.Tracks
{
    public interface IVideoTrack : ITrack
    {
        string Format { get; set; }
        string FormatProfile { get; set; }
        string FormatLevel { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        double Duration { get; set; }
        int Bitrate { get; set; }
        double PixelAspectRatio { get; set; }
        double DisplayAspectRatio { get; set; }
        string FrameRateMode { get; set; }
        double FrameRate { get; set; }
        string ColorSpace { get; set; }
        string ChromaSubSampling { get; set; }
        int BitDepth { get; set; }
        string EncodedLibrarySetteings { get; set; }
    }
}
