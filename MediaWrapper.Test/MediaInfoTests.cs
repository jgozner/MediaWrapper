using MediaWrapper.Exceptions;
using MediaWrapper.Interfaces;
using MKVToolkit.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MediaWrapper.Test
{
    public class MediaInfoTests 
    {

        [Fact]
        public async Task Info_VideoProperties_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);

            IVideoTrack videoTrack = info.VideoTracks.FirstOrDefault();

            Assert.NotNull(videoTrack);
            Assert.Equal(8, videoTrack.BitDepth);
            Assert.Equal(28656344, videoTrack.Bitrate);
            Assert.Equal("4:2:0", videoTrack.ChromaSubSampling);
            Assert.Equal("yuv", videoTrack.ColorSpace.ToLower());
            Assert.Equal(1.778, videoTrack.DisplayAspectRatio);
            Assert.Equal(60.022, videoTrack.Duration);
            Assert.Equal("avc", videoTrack.Format.ToLower());
            Assert.Equal("4", videoTrack.FormatLevel);
            Assert.Equal("high", videoTrack.FormatProfile.ToLower());
            Assert.Equal(3276.232, videoTrack.FrameRate);
            Assert.Equal("vfr", videoTrack.FrameRateMode.ToLower());
            Assert.Equal("cabac=1 / ref=3 / deblock=1:0:0 / analyse=0x3:0x113 / me=hex / subme=7 / psy=1 / psy_rd=1.00:0.00 / mixed_ref=1 / me_range=16 / chroma_me=1 / trellis=1 / 8x8dct=1 / cqm=0 / deadzone=21,11 / fast_pskip=1 / chroma_qp_offset=-2 / threads=18 / lookahead_threads=3 / sliced_threads=0 / nr=0 / decimate=1 / interlaced=0 / bluray_compat=0 / constrained_intra=0 / bframes=3 / b_pyramid=2 / b_adapt=1 / b_bias=0 / direct=1 / weightb=1 / open_gop=0 / weightp=2 / keyint=250 / keyint_min=23 / scenecut=40 / intra_refresh=0 / rc_lookahead=40 / rc=crf / mbtree=1 / crf=23.0 / qcomp=0.60 / qpmin=0 / qpmax=69 / qpstep=4 / ip_ratio=1.40 / aq=1:1.00", videoTrack.EncodedLibrarySetteings);
            Assert.Equal(1920, videoTrack.Width);
            Assert.Equal(1080, videoTrack.Height);
            Assert.Equal(1, videoTrack.PixelAspectRatio);
            Assert.Equal(0, videoTrack.StreamOrder);
        }

        [Fact]
        public async Task Info_EncodedVideoProperties_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);
            
            IVideoTrack videoTrack = info.VideoTracks.FirstOrDefault();

            Assert.NotNull(videoTrack);
        }


        [Fact]
        public async Task Info_AudioProperties_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Raw_MultipleTracks);

            IAudioTrack audioTrack = info.AudioTracks.FirstOrDefault();

            Assert.NotNull(audioTrack);
            Assert.Equal(3141027, audioTrack.Bitrate);
            Assert.Equal(20, audioTrack.Duration);
            Assert.Equal("lossless", audioTrack.CompressionMode.ToLower());
            Assert.Equal("mlp fba", audioTrack.Format.ToLower());
            Assert.Equal(960000, audioTrack.SamplingCount);
            Assert.Equal(48000, audioTrack.SamplingRate);
            Assert.Equal(1, audioTrack.StreamOrder);
            Assert.Equal("en", audioTrack.Language.ToLower());
        }

        [Fact]
        public async Task Info_ImageSubtitleProperties_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.Image_Subtitles);

            ISubtitleTrack subtitleTrack = info.SubtitleTracks.FirstOrDefault();

            Assert.NotNull(subtitleTrack);
            Assert.Equal(54092, subtitleTrack.Bitrate);
            Assert.Equal(8193.184, subtitleTrack.Duration);
            Assert.Equal("en", subtitleTrack.Language.ToLower());
            Assert.Equal("s_hdmv/pgs", subtitleTrack.CodecId.ToLower());
            Assert.Equal("pgs", subtitleTrack.Format.ToLower());
            Assert.Equal(0, subtitleTrack.StreamOrder);
        }

        [Fact]
        public async Task Info_TextSubtitleProperties_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.Text_Subtitles);

            ISubtitleTrack subtitleTrack = info.SubtitleTracks.FirstOrDefault();

            Assert.NotNull(subtitleTrack);
            Assert.Equal(0, subtitleTrack.Bitrate);
            Assert.Equal(0, subtitleTrack.Duration);
            Assert.Equal("subrip", subtitleTrack.Format.ToLower());
            Assert.Equal(0, subtitleTrack.StreamOrder);
        }
    }
}
