using System.Linq;
using Xunit;

namespace HexDump.Tests
{
    public class HexDump_Format_Test
    {

        [Fact]
        public void When_Encode_16_Then_ok()
        {
            var data = new byte[16];
            var expected = @"
0000    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
".Trim();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void When_Encode_32_Then_ok()
        {
            var data = new byte[32];
            var expected = @"
0000    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0010    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
".Trim();;
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void When_Encode_48_Then_ok()
        {
            var data = new byte[48];
            var expected = @"
0000    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0010    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0020    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
".Trim();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void When_Encode_256_Then_ok()
        {
            var data = new byte[256];
            var expected = @"
0000    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0010    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0020    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0030    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0040    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0050    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0060    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0070    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0080    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0090    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
00A0    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
00B0    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
00C0    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
00D0    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
00E0    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
00F0    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
".Trim();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void When_Encode_8_Then_ok()
        {
            var data = new byte[8];
            var expected = @"
0000    00 00 00 00 00 00 00 00                             ........         ".TrimStart();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void When_Encode_0_Then_ok()
        {
            var data = new byte[0];
            var expected = @"";
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void When_Encode_24_Then_ok()
        {
            var data = new byte[24];
            var expected = @"
0000    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0010    00 00 00 00 00 00 00 00                             ........         ".TrimStart();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void When_Encode_40_Then_ok()
        {
            var data = new byte[40];
            var expected = @"
0000    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0010    00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00    ........ ........
0020    00 00 00 00 00 00 00 00                             ........         ".TrimStart();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void When_Encode_40_one_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 1, 40).ToArray();

            var expected = @"
0000    01 01 01 01 01 01 01 01  01 01 01 01 01 01 01 01    ........ ........
0010    01 01 01 01 01 01 01 01  01 01 01 01 01 01 01 01    ........ ........
0020    01 01 01 01 01 01 01 01                             ........         ".TrimStart();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void When_Encode_100_ff_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 0xff, 100).ToArray();

            var expected = @"
0000    FF FF FF FF FF FF FF FF  FF FF FF FF FF FF FF FF    ÿÿÿÿÿÿÿÿ ÿÿÿÿÿÿÿÿ
0010    FF FF FF FF FF FF FF FF  FF FF FF FF FF FF FF FF    ÿÿÿÿÿÿÿÿ ÿÿÿÿÿÿÿÿ
0020    FF FF FF FF FF FF FF FF  FF FF FF FF FF FF FF FF    ÿÿÿÿÿÿÿÿ ÿÿÿÿÿÿÿÿ
0030    FF FF FF FF FF FF FF FF  FF FF FF FF FF FF FF FF    ÿÿÿÿÿÿÿÿ ÿÿÿÿÿÿÿÿ
0040    FF FF FF FF FF FF FF FF  FF FF FF FF FF FF FF FF    ÿÿÿÿÿÿÿÿ ÿÿÿÿÿÿÿÿ
0050    FF FF FF FF FF FF FF FF  FF FF FF FF FF FF FF FF    ÿÿÿÿÿÿÿÿ ÿÿÿÿÿÿÿÿ
0060    FF FF FF FF                                         ÿÿÿÿ             ".TrimStart();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }

        [Fact]
        public void When_Encode_40_61_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 40).ToArray();

            var expected = @"
0000    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
0010    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
0020    61 61 61 61 61 61 61 61                             aaaaaaaa         ".TrimStart();
            
            var result = HexDump.Format(data);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(expected, result2);
            Assert.Equal(expected, result);
        }
    }
}
