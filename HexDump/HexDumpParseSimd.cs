// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace HexDump
{
    public  static partial class HexDump
    {
        private static readonly byte[] _lookupSimd = new byte[]
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
        public static byte[] ParseSimd(string dump)
        {

            
            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................
            //00000000   01 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00   ................

            var lb = new List<int>();
            var hb = new List<int>();
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
                    lb.Add(_lookupSimd[span[i + 1]]);
                    hb.Add(_lookupSimd[span[i + 2]]);
                }
            }

            var ints = Simd(lb.ToArray(), hb.ToArray());
            var result = new byte[ints.Length];
            for (int i = 0; i < ints.Length; i++)
            {
                result[i] = (byte) ints[i];
            }

            return result;
        }

        public static int[] Simd(int[] lb, int[] hb)
        {
            
            var simdLength = Vector<int>.Count;
            var result = new int[lb.Length];
            var hexs = new Vector<int>(16);

            var i = 0;
            for (i = 0; i <= lb.Length - simdLength; i += simdLength) {
                
                var vl = new Vector<int>(lb, i);
                var vh = new Vector<int>(hb, i);
                (vl * hexs + vh).CopyTo(result, i);
            }

            return result;
        }

    }
}
