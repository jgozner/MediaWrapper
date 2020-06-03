using MediaWrapper.Enums;
using MediaWrapper.Helpers;
using MediaWrapper.Tracks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MKVToolkit.Tracks
{
    public class AudioTrack : IAudioTrack
    {
        public int ID { get; set; }
        public int StreamOrder { get; internal set; }
        public string Format { get; set; }
        public string CodecId { get; set; }
        public double Duration { get; set; }
        public FileInfo FileInfo { get; set; }
        public int Bitrate { get; set; }
        public int SamplingRate { get; set; }
        public int SamplingCount { get; set; }
        public string CompressionMode { get; set; }
        public string Language { get; set; }

        private Extension _extension;

        public Extension GetExtension()
        {
            return _extension ?? ExtensionHelper.GetAudioExtension(new AudioCodec(CodecId));
        }

        public void SetExtension(Extension extension)
        {
            _extension = extension;
        }
    }
}
