// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;

namespace HexDump
{
    public  static partial class HexDump
    {
        /// <summary>
        /// Parse HexDump into a byte array
        /// </summary>
        /// <param name="dump"></param>
        /// <returns></returns>
        public static byte[] ParseConvert(string dump)
        {

            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................
            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................

            var result = new List<byte>();
            var span = dump.AsSpan();
            for (int i = 0; i < span.Length - 3; i++)
            {
                
                if (span[i] == ' ' && span[i+3] == ' '
                    && ((span[i+1] >= '0' && span[i+1] <= '9')
                        || (span[i+1] >= 'a' && span[i+1] <= 'f')
                        || (span[i+1] >= 'A' && span[i+1] <= 'F')
                        || (span[i+2] >= '0' && span[i+2] <= '9')
                        || (span[i+2] >= 'a' && span[i+2] <= 'f')
                        || (span[i+2] >= 'A' && span[i+2] <= 'F')
                    )
                    )
                {
                    var s = span.Slice(i + 1, 2).ToString();
                    byte b = Convert.ToByte(s, 16);
                    result.Add(b);
                }
            }

            return result.ToArray();
        }

    }
}
