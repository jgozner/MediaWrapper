using MediaWrapper.Enums;
using MediaWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MKVToolkit.Tracks
{
    public class SubtitleTrack : ISubtitleTrack
    {
        public int ID { get; set; }
        public int StreamOrder { get; set; }
        public string Format { get; set; }
        public string CodecId { get; set; }
        public double Duration { get; set; }
        public FileInfo FileInfo { get; set; }
        public int Bitrate { get; set; }
        public string Language { get; set; }
        public string FileName { get; internal set; }

        private Extension _extension;

        public Extension GetExtension()
        {
            return _extension ?? ExtensionHelper.GetSubtitleExtension(new SubtitleCodec(CodecId));
        }
        public void SetExtension(Extension extension)
        {
            _extension = extension;
        }
    }
}
