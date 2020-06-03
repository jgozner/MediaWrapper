using MediaWrapper.Enums;
using MediaWrapper.Helpers;
using MKVToolkit.Tracks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MediaWrapper.Test
{
    public class ExtensionTests
    {
        [Fact]
        public void Extension_Video_MP4_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.MPEG1);
            Assert.Equal("mp4", extension.Name);
        }

        [Fact]
        public void Extension_Video_H264_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.H264);
            Assert.Equal("264", extension.Name);
        }

        [Fact]
        public void Extension_Video_HEVC_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.HEVC);
            Assert.Equal("265", extension.Name);
        }

        [Fact]
        public void Extension_Video_REAL_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.REAL);
            Assert.Equal("rm", extension.Name);
        }

        [Fact]
        public void Extension_Video_THEORA_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.THEORA);
            Assert.Equal("ogg", extension.Name);
        }

        [Fact]
        public void Extension_Video_VP9_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.VP9);
            Assert.Equal("vp9", extension.Name);
        }

        [Fact]
        public void Extension_Video_VP8_True()
        {
            var extension = ExtensionHelper.GetVideoExtension(VideoCodec.VP8);
            Assert.Equal("vp8", extension.Name);
        }

        [Fact]
        public void Extension_Audio_AC3_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.AC3);
            Assert.Equal("ac3", extension.Name);
        }

        [Fact]
        public void Extension_Audio_EAC3_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.EAC3);
            Assert.Equal("ac3", extension.Name);
        }

        [Fact]
        public void Extension_Audio_ALAC_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.ALAC);
            Assert.Equal("caf", extension.Name);
        }

        [Fact]
        public void Extension_Audio_DTS_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.DTS);
            Assert.Equal("dts", extension.Name);
        }

        [Fact]
        public void Extension_Audio_FLAC_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.FLAC);
            Assert.Equal("flac", extension.Name);
        }

        [Fact]
        public void Extension_Audio_MP2_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.MP2);
            Assert.Equal("mp2", extension.Name);
        }

        [Fact]
        public void Extension_Audio_MP3_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.MP3);
            Assert.Equal("mp3", extension.Name);
        }

        [Fact]
        public void Extension_Audio_OPUS_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.OPUS);
            Assert.Equal("opus", extension.Name);
        }

        [Fact]
        public void Extension_Audio_PCM_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.PCM);
            Assert.Equal("wav", extension.Name);
        }

        [Fact]
        public void Extension_Audio_REAL_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.REAL);
            Assert.Equal("ra", extension.Name);
        }

        [Fact]
        public void Extension_Audio_TRUEHD_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.TRUEHD);
            Assert.Equal("thd", extension.Name);
        }

        [Fact]
        public void Extension_Audio_MLP_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.MLP);
            Assert.Equal("mlp", extension.Name);
        }

        [Fact]
        public void Extension_Audio_AAC_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.AAC);
            Assert.Equal("aac", extension.Name);
        }

        [Fact]
        public void Extension_Audio_AAC2_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.AAC2);
            Assert.Equal("aac", extension.Name);
        }

        [Fact]
        public void Extension_Audio_AAC4_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.AAC4);
            Assert.Equal("aac", extension.Name);
        }

        [Fact]
        public void Extension_Audio_VORBIS_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.VORBIS);
            Assert.Equal("ogg", extension.Name);
        }

        [Fact]
        public void Extension_Audio_WAVPACK_True()
        {
            var extension = ExtensionHelper.GetAudioExtension(AudioCodec.WAVPACK);
            Assert.Equal("wv", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_PGS_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.PGS);
            Assert.Equal("sup", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_Kate_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.KATE);
            Assert.Equal("ogg", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_TEXT_SSA_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.TEXT_SSA);
            Assert.Equal("ssa", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_TEXT_ASS_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.TEXT_ASS);
            Assert.Equal("ass", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_SSA_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.SSA);
            Assert.Equal("ssa", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_ASS_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.ASS);
            Assert.Equal("ass", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_S_TEXT_UTF_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.TEXT_UTF);
            Assert.Equal("srt", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_S_TEXT_ASCII_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.TEXT_ASCII);
            Assert.Equal("srt", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_S_TEXT_USF_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.TEXT_USF);
            Assert.Equal("usf", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_S_TEXT_WEB_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.TEXT_WEB);
            Assert.Equal("webvtt", extension.Name);
        }

        [Fact]
        public void Extension_Subtitle_S_SUB_True()
        {
            var extension = ExtensionHelper.GetSubtitleExtension(SubtitleCodec.SUB);
            Assert.Equal("sub", extension.Name);
        }

    }
}
