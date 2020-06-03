using System;
using System.IO;

namespace MediaWrapper.Test
{
    internal static class Resources
    {
        internal static readonly string MKV_Encoded_MultipleTracks = GetResourceFilePath("bluray_hobsshaw_encoded.mkv");
        internal static readonly string MKV_Raw_MultipleTracks = GetResourceFilePath("bluray_hobsshaw_raw.mkv");
        internal static readonly string Image_Subtitles = GetResourceFilePath("video_subtitles.mks");
        internal static readonly string Text_Subtitles = GetResourceFilePath("text_subtitles.srt");

        internal static string GetResourceFilePath(string fileName) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
    }
}
