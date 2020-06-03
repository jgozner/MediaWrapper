using MediaWrapper.Models;
using MediaWrapper.Tracks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaWrapper.Interfaces
{
    public interface IExtraction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IExtractionResult> Start();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tracks"></param>
        /// <returns></returns>
        IExtraction AddTrack<T>(params T[] tracks) where T : ITrack;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        IExtraction SetOutputDirectory(string directory);
    }
}
