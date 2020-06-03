using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MediaWrapper.Enums
{
    public class Extension
    {
        public static readonly Extension MP4 = new Extension("mp4");

        public static readonly Extension MKV = new Extension("mkv");

        public static readonly Extension MOV = new Extension("mov");

        public static readonly Extension AVI = new Extension("avi");

        public static readonly Extension FLV = new Extension("flv");

        public static readonly Extension MPG = new Extension("mpg");

        public static readonly Extension VP9 = new Extension("vp9");

        public static readonly Extension VP8 = new Extension("vp8");

        public static readonly Extension H264 = new Extension("264");

        public static readonly Extension H265 = new Extension("265");

        public static readonly Extension RM = new Extension("rm");

        public static readonly Extension AC3 = new Extension("ac3");

        public static readonly Extension CAF = new Extension("caf");

        public static readonly Extension DTS = new Extension("dts");

        public static readonly Extension FLAC = new Extension("flac");

        public static readonly Extension MP2 = new Extension("mp2");

        public static readonly Extension MP3 = new Extension("mp3");

        public static readonly Extension OPUS = new Extension("opus");

        public static readonly Extension RA = new Extension("ra");

        public static readonly Extension THD = new Extension("thd");

        public static readonly Extension MLP = new Extension("mlp");

        public static readonly Extension AAC = new Extension("aac");

        public static readonly Extension WV = new Extension("wv");

        public static readonly Extension WAV = new Extension("wav");

        public static readonly Extension OGG = new Extension("ogg");

        public static readonly Extension SUP = new Extension("sup");

        public static readonly Extension SSA = new Extension("ssa");

        public static readonly Extension ASS = new Extension("ass");

        public static readonly Extension SRT = new Extension("srt");

        public static readonly Extension USF = new Extension("usf");

        public static readonly Extension WEBVTT = new Extension("webvtt");

        public static readonly Extension SUB = new Extension("sub");

        public string Name { get; }

        private Extension(string name)
        {
            Name = name;
        }
    }
}
