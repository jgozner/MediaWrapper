using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWrapper.Models
{
    internal class MediaInfoOutput
    {
        public Media Media { get; set; }
           
    }

    internal class Media
    {
        public TrackInfoOutput[] Track { get; set; }
    }

    internal class TrackInfoOutput
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public int ID { get; set; }
        public int StreamOrder { get; set; }
        public string Format { get; set; }
        public string Format_Profile { get; set; }
        public string Format_Level { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string CodecID { get; set; }
        public double Duration { get; set; }
        public int Bitrate { get; set; }
        public double PixelAspectRatio { get; set; }
        public double DisplayAspectRatio { get; set; }
        public string FrameRate_Mode { get; set; }
        public double FrameRate { get; set; }
        public string ColorSpace { get; set; }
        public string ChromaSubSampling { get; set; }
        public int BitDepth { get; set; }
        public string Encoded_Library_Settings { get; set; }
        public int SamplingRate { get; set; }
        public int SamplingCount { get; set; }
        public string Compression_Mode { get; set; }
        public string Language { get; set; }
    }
}
