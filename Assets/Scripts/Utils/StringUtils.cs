using System.Collections.Generic;
using System;

namespace Joserbala.Utils
{
    public class StringUtils
    {

        /// <summary>
        /// Removes null and empty variables from <paramref name="array"/>.
        /// <para>If <paramref name="truncateWhiteSpaces"/> is true, it also removes variables with white spaces only.</para>
        /// </summary>
        /// <param name="array">The string array to be iterated.</param>
        /// <param name="truncateWhiteSpaces">True if variables with white spaces have to be removed, false otherwise.</param>
        /// <returns>The <paramref name="array"/> without null or empty variables (and without white spaces if <paramref name="truncateWhiteSpaces"/> is true).</returns>
        public static string[] TruncateNullOrEmptyValuesArray(string[] array, bool truncateWhiteSpaces = false)
        {
            Func<string, bool> truncateType = truncateWhiteSpaces ? string.IsNullOrWhiteSpace : string.IsNullOrEmpty;
            var tempList = new List<string>();

            foreach (string variable in array)
            {
                if (!truncateType(variable))
                    tempList.Add(variable);
            }

            array = tempList.ToArray();

            return array;
        }
    }
}