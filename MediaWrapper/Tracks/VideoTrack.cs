using MediaWrapper.Enums;
using MediaWrapper.Helpers;
using System;
using System.IO;

namespace MKVToolkit.Tracks
{
    public class VideoTrack : IVideoTrack
    {
        public int ID { get; set; }
        public int StreamOrder { get; set; }
        public string Format { get; set; }
        public string FormatProfile { get; set; }
        public string FormatLevel { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public FileInfo FileInfo { get; set; }
        public string CodecId { get; set; }
        public double Duration { get; set; }
        public int Bitrate { get; set; }
        public double PixelAspectRatio { get; set; }
        public double DisplayAspectRatio { get; set; }
        public string FrameRateMode { get; set; }
        public double FrameRate { get; set; }
        public string ColorSpace { get; set; }
        public string ChromaSubSampling { get; set; }
        public int BitDepth { get; set; }
        public string EncodedLibrarySetteings { get; set; }
        public string FileName { get; set; }

        private Extension _extension;

        public Extension GetExtension()
        {
            return _extension ?? ExtensionHelper.GetVideoExtension(new VideoCodec(CodecId));
        }

        public void SetExtension(Extension extension)
        {
            _extension = extension;
        }

    }
}
