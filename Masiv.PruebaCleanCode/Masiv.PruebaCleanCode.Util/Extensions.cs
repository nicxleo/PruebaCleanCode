using System;
using System.Collections.Generic;
using System.Linq;

namespace Masiv.PruebaCleanCode.Util
{
    public static class Extensions
    {
        public static List<T> Clone<T>(IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}