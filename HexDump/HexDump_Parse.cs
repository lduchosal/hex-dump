// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HexDump
{
    public  static partial class HexDump
    {
        /// <summary>
        /// Parse HexDump into a byte array
        /// </summary>
        /// <param name="dump"></param>
        /// <param name="columnWidth"></param>
        /// <param name="columnCount"></param>
        /// <param name="includeOffset"></param>
        /// <param name="includeAscii"></param>
        /// <returns></returns>
        public static byte[] Parse(string dump, int columnWidth = 8, int columnCount = 2, bool includeOffset = true, bool includeAscii = true)
        {

            string rio = includeOffset ? "((?<offset>[0-9a-f]+)\\s+)" : "";
            string ria = includeAscii ? "(?<dump>.+)" : "";
            
            int hexaWidth = (columnWidth * 3 * columnCount) + columnCount - 1 - 1;
            var _re = new Regex($"^{rio}(?<hexa>[0-9a-f\\s]{{{hexaWidth}}}){ria}$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................
            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................

            string line;
            var result = new List<byte>();
            using (var sr = new StringReader(dump))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var capture = _re.Match(line);
                    if (!capture.Success) continue;
                    var hexa = capture.Groups["hexa"]
                            .Value
                            .Replace(" ", "")
                        ;

                    var bytes = Enumerable.Range(0, hexa.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hexa.Substring(x, 2), 16))
                        ;

                    result.AddRange(bytes);
                } 
            }

            return result.ToArray();
        }

    }
}
