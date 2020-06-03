using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MediaWrapper.Enums
{
    [ExcludeFromCodeCoverage]
    public class AudioCodec
    {
        public static readonly AudioCodec AC3 = new AudioCodec("A_AC3");

        public static readonly AudioCodec EAC3 = new AudioCodec("A_EAC3");

        public static readonly AudioCodec ALAC = new AudioCodec("A_ALAC");

        public static readonly AudioCodec DTS = new AudioCodec("A_DTS");

        public static readonly AudioCodec FLAC = new AudioCodec("A_FLAC");

        public static readonly AudioCodec MP2 = new AudioCodec("A_A_MPEG/L2");

        public static readonly AudioCodec MP3 = new AudioCodec("A_MPEG/L3");

        public static readonly AudioCodec OPUS = new AudioCodec("A_OPUS");

        public static readonly AudioCodec PCM = new AudioCodec("A_PCM/INT/LIT, A_PCM/INT/BIG");

        public static readonly AudioCodec REAL = new AudioCodec("A_REAL/*");

        public static readonly AudioCodec TRUEHD = new AudioCodec("A_TRUEHD");
        
        public static readonly AudioCodec MLP = new AudioCodec("A_MLP");

        public static readonly AudioCodec AAC = new AudioCodec("A_AAC");

        public static readonly AudioCodec AAC2 = new AudioCodec("A_AAC/MPEG2/*");

        public static readonly AudioCodec AAC4 = new AudioCodec("A_AAC/MPEG4/*");

        public static readonly AudioCodec VORBIS = new AudioCodec("A_VORBIS");

        public static readonly AudioCodec WAVPACK = new AudioCodec("A_WAVPACK4");

        /// <summary>
        ///     Audio codec
        /// </summary>
        public string Codec { get; }

        public AudioCodec(string codec)
        {
            Codec = codec;
        }
    }
}
