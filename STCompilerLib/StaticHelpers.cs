using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib
{
    public static class StaticHelpers
    {
        /// <summary>
        /// The SplitList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="locations">The locations<see cref="List{T}"/></param>
        /// <param name="nSize">The nSize<see cref="int"/></param>
        /// <returns>The <see>
        ///         <cref>List{List{T}}</cref>
        ///     </see>
        /// </returns>
        public static List<List<T>> SplitList<T>(List<T> locations, int nSize)
        {
            List<List<T>> list = new List<List<T>>();
            for (int i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }
            return list;
        }
    }
}
