using MediaWrapper.Enums;
using MediaWrapper.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Helpers
{
    internal static class ExtensionHelper
    {
        /// <summary>
        ///  Returns the appropriate extension given a video codec
        /// </summary>
        /// <param name="videoCodec"></param>
        /// <returns></returns>
        public static Extension GetVideoExtension(VideoCodec videoCodec)
        {
            if (videoCodec.Codec == VideoCodec.MPEG1.Codec || videoCodec.Codec == VideoCodec.MPEG2.Codec)
            {
                return Extension.MP4;
            }

            if ( videoCodec.Codec == VideoCodec.VP9.Codec)
            {
                return Extension.VP9;
            }

            if ( videoCodec.Codec == VideoCodec.VP8.Codec)
            {
                return Extension.VP8;
            }

            if ( videoCodec.Codec == VideoCodec.H264.Codec)
            {
                return Extension.H264;
            }

            if ( videoCodec.Codec == VideoCodec.HEVC.Codec)
            {
                return Extension.H265;
            }

            if ( videoCodec.Codec == VideoCodec.REAL.Codec)
            {
                return Extension.RM;
            }

            if ( videoCodec.Codec == VideoCodec.THEORA.Codec)
            {
                return Extension.OGG;
            }

            throw new UnkownExtentionException($"Unkown extension for codec: {videoCodec.Codec}");
        }

        /// <summary>
        /// Returns the appropriate extension given an audio codec
        /// </summary>
        /// <param name="audioCodec"></param>
        /// <returns></returns>
        public static Extension GetAudioExtension(AudioCodec audioCodec)
        {

            if (audioCodec.Codec == AudioCodec.AC3.Codec || audioCodec.Codec == AudioCodec.EAC3.Codec)
            {
                return Extension.AC3;
            }

            if (audioCodec.Codec == AudioCodec.ALAC.Codec)
            {
                return Extension.CAF;
            }

            if (audioCodec.Codec == AudioCodec.DTS.Codec)
            {
                return Extension.DTS;
            }

            if (audioCodec.Codec == AudioCodec.FLAC.Codec)
            {
                return Extension.FLAC;
            }

            if (audioCodec.Codec == AudioCodec.MP2.Codec)
            {
                return Extension.MP2;
            }

            if (audioCodec.Codec == AudioCodec.MP3.Codec)
            {
                return Extension.MP3;
            }

            if (audioCodec.Codec == AudioCodec.OPUS.Codec)
            {
                return Extension.OPUS;
            }

            if (audioCodec.Codec == AudioCodec.REAL.Codec)
            {
                return Extension.RA;
            }

            if (audioCodec.Codec == AudioCodec.PCM.Codec)
            {
                return Extension.WAV;
            }

            if (audioCodec.Codec == AudioCodec.TRUEHD.Codec)
            {
                return Extension.THD;
            }

            if (audioCodec.Codec == AudioCodec.MLP.Codec)
            {
                return Extension.MLP;
            }

            if (audioCodec.Codec == AudioCodec.AAC.Codec || audioCodec.Codec == AudioCodec.AAC2.Codec || audioCodec.Codec == AudioCodec.AAC4.Codec)
            {
                return Extension.AAC;
            }

            if (audioCodec.Codec == AudioCodec.VORBIS.Codec)
            {
                return Extension.OGG;
            }

            if (audioCodec.Codec == AudioCodec.WAVPACK.Codec)
            {
                return Extension.WV;
            }

            throw new UnkownExtentionException($"Unkown extension for codec: {audioCodec.Codec}");
        }

        /// <summary>
        /// Returns the appropriate extension given an subtitle codec
        /// </summary>
        /// <param name="subtitleCodec"></param>
        /// <returns></returns>
        public static Extension GetSubtitleExtension(SubtitleCodec subtitleCodec)
        {
            if (subtitleCodec.Codec == SubtitleCodec.PGS.Codec)
            {
                return Extension.SUP;
            }

            if (subtitleCodec.Codec == SubtitleCodec.KATE.Codec)
            {
                return Extension.OGG;
            }

            if (subtitleCodec.Codec == SubtitleCodec.TEXT_SSA.Codec || subtitleCodec.Codec == SubtitleCodec.SSA.Codec)
            {
                return Extension.SSA;
            }

            if (subtitleCodec.Codec == SubtitleCodec.TEXT_ASS.Codec || subtitleCodec.Codec == SubtitleCodec.ASS.Codec)
            {
                return Extension.ASS;
            }

            if (subtitleCodec.Codec == SubtitleCodec.TEXT_ASCII.Codec || subtitleCodec.Codec == SubtitleCodec.TEXT_UTF.Codec)
            {
                return Extension.SRT;
            }

            if (subtitleCodec.Codec == SubtitleCodec.TEXT_USF.Codec)
            {
                return Extension.USF;
            }

            if (subtitleCodec.Codec == SubtitleCodec.TEXT_WEB.Codec)
            {
                return Extension.WEBVTT;
            }

            if (subtitleCodec.Codec == SubtitleCodec.SUB.Codec)
            {
                return Extension.SUB;
            }

            throw new UnkownExtentionException($"Unkown extension for codec: {subtitleCodec.Codec}");
        }

    }
}
