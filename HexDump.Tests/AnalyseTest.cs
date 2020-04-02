using System;
using System.Linq;
using Xunit;

namespace HexDump.Tests
{
    public class AnalyseTest
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
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
            Assert.Equal(1, config.Eol);
        }
    }
}
