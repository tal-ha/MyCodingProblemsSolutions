using eulerproject.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject
{
    public static class Helpers
    {
        #region Fields

        #endregion Fields

        #region Methods

        public static bool IsMirror(this int[] left, int[] right)
        {
            if (left.Length != right.Length)
                return false;

            int len = left.Length;
            for (int i = 0, j = len - 1; i < len; i++, j--)
            {
                if (left[i] != right[j])
                    return false;
            }

            return true;
        }

        public static int AsInt(this int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                res += array[i] * Convert.ToInt32(Math.Pow(10, array.Length - i - 1));
            }

            return res;
        }

        public static string AsString(this int[] array)
        {
            return string.Join("", array);
        }

        public static string AsString(this char[] array)
        {
            return string.Join("", array);
        }
        
        #endregion Methods
    }
}
