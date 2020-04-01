// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexDump
{
    public  static partial class HexDump
    {
        private static readonly int[] _lookup = new int[]
        {
            0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,  0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
            0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,  0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
            0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,  0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
            0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7,  0x8, 0x9, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
            0x0, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF, 0x0,  0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
            0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,  0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
            0x0, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf, 0x0,  0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 
        };

        /// <summary>
        /// Parse HexDump into a byte array
        /// </summary>
        /// <param name="dump"></param>
        /// <returns></returns>
        public static byte[] Parse(string dump)
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
                    

                    int dec = (
                        _lookup[span[i + 1]] * 10 
                        + _lookup[span[i + 2]] 
                        ) * 16 / 10;
                    
                    result.Add((byte)dec);
                }
            }

            return result.ToArray();
        }

    }
}
