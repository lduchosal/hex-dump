using System;
using System.Linq;
using Xunit;

namespace HexDump.Tests
{
    public class AnalyseTests
    {

        
        [Fact]
        public void When_Ascii_In_Ascii_Dont_Match()
        {
            var data = @"
0000    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
0000    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
0000    9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(8, config.Offset);
            Assert.Equal(48, config.Hex);
            Assert.Equal(21, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }
        
        [Fact]
        public void When_NoOffset_NoAscii()
        {
            var data = @"
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(48, config.Hex);
            Assert.Equal(0, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }


        [Fact]
        public void When_NoOffset_NoAscii_OneLine()
        {
            var data = @"
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(48, config.Hex);
            Assert.Equal(0, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }

        [Fact]
        public void When_NoOffset_NoAscii_23_OneLine()
        {
            var data = @"
9A 20 31 32 20 9A 9A 9A
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(23, config.Hex);
            Assert.Equal(0, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }



        [Fact]
        public void When_NoOffset_Ascii_In_Ascii_Dont_Match()
        {
            var data = @"
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(48, config.Hex);
            Assert.Equal(21, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }
        
        [Fact]
        public void When_NoOffset_Ascii_In_Ascii_OneLine_Match()
        {
            var data = @"
9A 20 31 32 20 9A 9A 9A  9A 9A 9A 9A 9A 9A 9A 9A    . 12 ... ........
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(48, config.Hex);
            Assert.Equal(21, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }
        
        [Fact]
        public void When_NoOffset_Ascii_2_In_Ascii_OneLine_Match()
        {
            var data = @"
9A
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(2, config.Hex);
            Assert.Equal(0, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }
        
        [Fact]
        public void When_NoOffset_Ascii_4_In_Ascii_OneLine_Match()
        {
            var data = @"
9A 9A
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(0, config.Offset);
            Assert.Equal(5, config.Hex);
            Assert.Equal(0, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }
        
        
        [Fact]
        public void When_56a_Columns1_Width8_Ascii0_Offset1_Then_ok()
        {
            
            var data = @"
0000    61 61 61 61 61 61 61 61
0008    61 61 61 61 61 61 61 61
0010    61 61 61 61 61 61 61 61
0018    61 61 61 61 61 61 61 61
0020    61 61 61 61 61 61 61 61
0028    61 61 61 61 61 61 61 61
0030    61 61 61 61 61 61 61 61
".Trim();
            
            var config = HexDump.Analyse(data.AsSpan());

            Assert.Equal(8, config.Offset);
            Assert.Equal(23, config.Hex);
            Assert.Equal(0, config.Ascii);
            Assert.Equal(1, config.NewLine);
        }


        [Fact]
        public void When_56a_Columns1_Width8_Ascii1_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 3;
            int width = 4;
            bool offset = true;
            bool ascii = true;
            var expected = @"
0000    61 61 61 61  61 61 61 61  61 61 61 61    aaaa aaaa aaaa
000C    61 61 61 61  61 61 61 61  61 61 61 61    aaaa aaaa aaaa
0018    61 61 61 61  61 61 61 61  61 61 61 61    aaaa aaaa aaaa
0024    61 61 61 61  61 61 61 61  61 61 61 61    aaaa aaaa aaaa
0030    61 61 61 61  61 61 61 61                 aaaa aaaa     ".TrimStart();
            var result = HexDump.Format(data, width, columns, offset, ascii);
            Assert.Equal(expected, result);

            var config = HexDump.Analyse(result.AsSpan());
            Assert.Equal(8, config.Offset);
            Assert.Equal(37, config.Hex);
            Assert.Equal(18, config.Ascii);
            //Assert.Equal(1, config.NewLine);
        }
    }
}
