using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MediaWrapper.Enums
{
    [ExcludeFromCodeCoverage]
    public class ExtractionMode
    {

        public static readonly ExtractionMode Tracks = new ExtractionMode("tracks");

        public static readonly ExtractionMode Tags = new ExtractionMode("tags");

        public static readonly ExtractionMode Attachments = new ExtractionMode("attachments");

        public static readonly ExtractionMode Chapters = new ExtractionMode("chapters");

        public static readonly ExtractionMode Timecodes = new ExtractionMode("timecodes_v2");

        internal string Name { get; set; }

        private ExtractionMode(string name)
        {
            Name = name;        
        }
    }
}
