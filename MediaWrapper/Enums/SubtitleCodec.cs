using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MediaWrapper.Enums
{
    [ExcludeFromCodeCoverage]
    public class SubtitleCodec
    {
        public static readonly SubtitleCodec PGS = new SubtitleCodec("S_HDMV/PGS");

        public static readonly SubtitleCodec TextST = new SubtitleCodec("S_HDMV/TEXTST");

        public static readonly SubtitleCodec KATE = new SubtitleCodec("S_KATE");

        public static readonly SubtitleCodec TEXT_SSA = new SubtitleCodec("S_TEXT/SSA");

        public static readonly SubtitleCodec TEXT_ASS = new SubtitleCodec("S_TEXT/ASS");

        public static readonly SubtitleCodec SSA = new SubtitleCodec("S_SSA");

        public static readonly SubtitleCodec ASS = new SubtitleCodec("S_ASS");

        public static readonly SubtitleCodec TEXT_UTF = new SubtitleCodec("S_TEXT/UTF8");

        public static readonly SubtitleCodec TEXT_ASCII = new SubtitleCodec("S_TEXT/ASCII");

        public static readonly SubtitleCodec TEXT_USF = new SubtitleCodec("S_TEXT/USF");

        public static readonly SubtitleCodec TEXT_WEB = new SubtitleCodec("S_TEXT/WEBVTT");

        public static readonly SubtitleCodec SUB = new SubtitleCodec("S_VOBSUB");

        public string Codec { get; private set; }

        public SubtitleCodec(string codec)
        {
            Codec = codec;
        }
    }
}

