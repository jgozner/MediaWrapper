using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MediaWrapper.Enums
{
    [ExcludeFromCodeCoverage]
    public class VideoCodec
    {
        public static readonly VideoCodec MPEG1 = new VideoCodec("V_MPEG1");

        public static readonly VideoCodec MPEG2 = new VideoCodec("V_MPEG2");

        public static readonly VideoCodec H264 = new VideoCodec("V_MPEG4/ISO/AVC");

        public static readonly VideoCodec HEVC = new VideoCodec("V_MPEG4/ISO/HEVC");

        public static readonly VideoCodec REAL = new VideoCodec("V_REAL/*");

        public static readonly VideoCodec THEORA = new VideoCodec("V_THEORA");

        public static readonly VideoCodec VP8 = new VideoCodec("V_VP8");

        public static readonly VideoCodec VP9 = new VideoCodec("V_VP9");

        public string Codec { get; }

        public VideoCodec(string codec)
        {
            Codec = codec;
        }
        

    }
}
