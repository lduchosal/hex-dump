// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexDump
{
    public  static partial class HexDump
    {
        static readonly Dictionary<char, int> _dic =new Dictionary<char, int>();

        static HexDump()
        {
            var keys = "0123456789ABCEDF";
            for (int i = 0; i < keys.Length; i++)
            {
                _dic[keys[i]] = i;
                if (i > 10)
                {
                    _dic[(char)(keys[i]+0x20)] = i;
                }
            }

        }
        /// <summary>
        /// Parse HexDump into a byte array
        /// </summary>
        /// <param name="dump"></param>
        /// <returns></returns>
        public static byte[] ParseDic(string dump)
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

                    int dec = (_dic[span[i + 1]] * 10 + _dic[span[i + 2]]) * 16 / 10;
                    result.Add((byte)dec);
                }
            }

            return result.ToArray();
        }

    }
}
