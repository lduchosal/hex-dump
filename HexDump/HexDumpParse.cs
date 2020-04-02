// Copyright (c) Drew Noakes. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexDump
{
    public  static partial class HexDump
    {

        public static byte[] Parse(string dump)
        {
            return ParseStasteMachine(dump);
        }

    }
}
