using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MediaWrapper.Enums
{
    [ExcludeFromCodeCoverage]
    public class Executable
    {
        public static readonly Executable MediaInfo = new Executable("mediainfo");
        
        public static readonly Executable MKVExtract = new Executable("mkvextract");

        public static readonly Executable MP4Box = new Executable("mp4box");

        public static readonly Executable FFmpeg = new Executable("ffmpeg");

        internal string Name { get; set; }

        private Executable(string name)
        {
            Name = name;
        }
    }
}
