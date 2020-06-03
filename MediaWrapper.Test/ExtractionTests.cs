using MediaWrapper.Enums;
using MediaWrapper.Exceptions;
using MediaWrapper.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MediaWrapper.Test
{
    public class ExtractionTests 
    {

        [Fact]
        public async Task Extract_MultipleTracks_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);

            var video_track = info.VideoTracks.First();
            var audio_track = info.AudioTracks.First();

            IExtractionResult result = await Extraction.New()
                                        .AddTrack(video_track)
                                        .AddTrack(audio_track)
                                        .SetOutputDirectory(Directory.GetCurrentDirectory())
                                        .Start()
                                        .ConfigureAwait(false);

            Assert.True(File.Exists(video_track.FileInfo.FullName));
            Assert.True(File.Exists(audio_track.FileInfo.FullName));

            File.Delete(video_track.FileInfo.FullName);
            File.Delete(audio_track.FileInfo.FullName);
        }

        [Fact]
        public async Task Extract_ChangeExtension_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);

            var video_track = info.VideoTracks.First();

            video_track.SetExtension(Extension.MKV);

            IExtractionResult result = await Extraction.New()
                                        .AddTrack(video_track)
                                        .SetOutputDirectory(Directory.GetCurrentDirectory())
                                        .Start()
                                        .ConfigureAwait(false);

            Assert.Equal(".mkv", Path.GetExtension(video_track.FileInfo.FullName));
            Assert.True(File.Exists(video_track.FileInfo.FullName));

            File.Delete(video_track.FileInfo.FullName);
        }

        [Fact]
        public async Task Extract_ResultDetails_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);

            var video_track = info.VideoTracks.First();

            IExtractionResult result = await Extraction.New()
                                        .AddTrack(video_track)
                                        .Start()
                                        .ConfigureAwait(false);

            var duration = result.EndTime - result.StartTime;

            Assert.True(duration.TotalMilliseconds > 1);
            Assert.True(result.Success);

            File.Delete(video_track.FileInfo.FullName);
        }

        [Fact]
        public async Task Extract_InvalidOutputDirectory_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);

            var audioTrack = info.AudioTracks.First();

            Action act = () =>  Extraction.New()
                .AddTrack(audioTrack)
                .SetOutputDirectory(@"F:\fakeDirectory\adawdj1o2312")
                .Start()
                .ConfigureAwait(false);

            Assert.Throws<InvalidInputException>(act);
        }

        [Fact]
        public async Task Extract_InvalidInputDifferentSources_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);
            IMediaInfo info_2 = await MediaInfo.Get(Resources.MKV_Raw_MultipleTracks);


            Action act = () => Extraction.New()
                .AddTrack(info.VideoTracks.First())
                .AddTrack(info_2.VideoTracks.First())
                .Start()
                .ConfigureAwait(false);

            Assert.Throws<InvalidInputException>(act);
        }

        [Fact]
        public async Task Extract_UnknownExtension_True()
        {
            IMediaInfo info = await MediaInfo.Get(Resources.MKV_Encoded_MultipleTracks);

            var audioTrack = info.AudioTracks.First();
            audioTrack.CodecId = "fakeCodec";

            Action act = () => Extraction.New()
                .AddTrack(audioTrack)
                .Start()
                .ConfigureAwait(false);

            Assert.Throws<UnkownExtentionException>(act);
        }
    }
}
