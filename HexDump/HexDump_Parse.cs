// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HexDump
{
    public  static partial class HexDump
    {
        
        private static readonly Regex _re =
            new Regex(@"^((?<offset>[0-9a-f]+)\s+)?(?<hexa>[0-9a-f\s]{48})\s+(?<dump>.+)?$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Parse HexDump into a byte array
        /// Support only hexdumped bytes array with these attributes:
        /// - columnWidth = 8
        /// - columnCount = 2
        /// - includeOffset = true
        /// - includeAscii = true
        ///
        /// </summary>
        /// <param name="dump"></param>
        /// <returns></returns>
        public static byte[] Parse(string dump )
        {
            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................
            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................

            var result = new List<byte>();
            var lines = dump.Split(Environment.NewLine.ToCharArray());
            foreach (var line in lines)
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
                    .ToArray();

                result.AddRange(bytes);
            }

            return result.ToArray();
        }

    }
}
