using System.Linq;
using Xunit;

namespace HexDump.Tests
{
    public class HexDumpFormatNeedFix
    {

        
        [Fact]
        public void When_Ascii_In_Ascii_Dont_Match()
        {
            var data = @"
0000    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
0010    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
0020    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
".Trim();
            
            var parsed = HexDump.Parse(data);
            var result2 = HexDump.Format(parsed);

            Assert.Equal(data, result2);
        }

        [Fact]
        public void When_NoOffest_Work()
        {
            var data = @"
9A 9A 9A 9A 9A 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    ........ ........
".Trim();
            
            var parsed = HexDump.Parse(data);
            var result2 = HexDump.Format(parsed, includeOffset: false);

            Assert.Equal(data, result2);
        }

        [Fact]
        public void When_NoAscii_Work()
        {
            var data = @"
0000    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A
".Trim();
            
            var parsed = HexDump.Parse(data);
            var result2 = HexDump.Format(parsed, includeAscii: false);

            Assert.Equal(data, result2);
        }
        

        [Fact]
        public void When_NoAscii_NoOffset_Work()
        {
            var data = @"
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A
".Trim();
            
            var parsed = HexDump.Parse(data);
            var result2 = HexDump.Format(parsed, includeOffset: false, includeAscii: false);

            Assert.Equal(data, result2);
        }

    }
}
