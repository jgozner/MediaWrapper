using MediaWrapper.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaWrapper.Tracks
{
    public interface ITrack
    {
        /// <summary>
        /// Source file of track
        /// </summary>
        FileInfo FileInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int StreamOrder { get; }

        /// <summary>
        /// 
        /// </summary>
        string CodecId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Extension GetExtension();

        /// <summary>
        /// Manually override the container to use
        /// </summary>
        void SetExtension(Extension extension);

    }
}
