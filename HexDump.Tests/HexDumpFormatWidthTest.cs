using System.Linq;
using Xunit;

namespace HexDump.Tests
{
    public class HexDumpFormatWidthTest
    {


        [Fact]
        public void When_Encode_56a_Columns1_Width8_Ascii1_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 1;
            int width = 8;
            bool offset = true;
            bool ascii = true;
            
            var expected = @"
0000    61 61 61 61 61 61 61 61    aaaaaaaa
0008    61 61 61 61 61 61 61 61    aaaaaaaa
0010    61 61 61 61 61 61 61 61    aaaaaaaa
0018    61 61 61 61 61 61 61 61    aaaaaaaa
0020    61 61 61 61 61 61 61 61    aaaaaaaa
0028    61 61 61 61 61 61 61 61    aaaaaaaa
0030    61 61 61 61 61 61 61 61    aaaaaaaa
".Trim();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }

        
        [Fact]
        public void When_Encode_56a_Columns1_Width8_Ascii1_Offset0_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 1;
            int width = 8;
            bool offset = false;
            bool ascii = true;
            
            var expected = @"
61 61 61 61 61 61 61 61    aaaaaaaa
61 61 61 61 61 61 61 61    aaaaaaaa
61 61 61 61 61 61 61 61    aaaaaaaa
61 61 61 61 61 61 61 61    aaaaaaaa
61 61 61 61 61 61 61 61    aaaaaaaa
61 61 61 61 61 61 61 61    aaaaaaaa
61 61 61 61 61 61 61 61    aaaaaaaa
".Trim();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }

        [Fact]
        public void When_Encode_56a_Columns1_Width8_Ascii0_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 1;
            int width = 8;
            bool offset = true;
            bool ascii = false;
            
            var expected = @"
0000    61 61 61 61 61 61 61 61
0008    61 61 61 61 61 61 61 61
0010    61 61 61 61 61 61 61 61
0018    61 61 61 61 61 61 61 61
0020    61 61 61 61 61 61 61 61
0028    61 61 61 61 61 61 61 61
0030    61 61 61 61 61 61 61 61
".Trim();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }


        [Fact]
        public void When_Encode_56a_Columns1_Width8_Ascii0_Offset0_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 1;
            int width = 8;
            bool offset = false;
            bool ascii = false;
            
            var expected = @"
61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61
".Trim();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }

        [Fact]
        public void When_Encode_56a_Columns2_Width8_Ascii1_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 2;
            int width = 8;
            bool offset = true;
            bool ascii = true;
            
            var expected = @"
0000    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
0010    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
0020    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
0030    61 61 61 61 61 61 61 61                             aaaaaaaa         ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }

        
        [Fact]
        public void When_Encode_56a_Columns2_Width8_Ascii1_Offset0_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 2;
            int width = 8;
            bool offset = false;
            bool ascii = true;
            
            var expected = @"
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa
61 61 61 61 61 61 61 61                             aaaaaaaa         ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }

        [Fact]
        public void When_Encode_56a_Columns2_Width8_Ascii0_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 2;
            int width = 8;
            bool offset = true;
            bool ascii = false;
            
            var expected = @"
0000    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
0010    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
0020    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
0030    61 61 61 61 61 61 61 61                         ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }
        
        
        [Fact]
        public void When_Encode_56a_Columns2_Width8_Ascii0_Offset0_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 2;
            int width = 8;
            bool offset = false;
            bool ascii = false;
            
            var expected = @"
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61                         ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }


        [Fact]
        public void When_Encode_56a_Columns3_Width8_Ascii1_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 3;
            int width = 8;
            bool offset = true;
            bool ascii = true;
            
            var expected = @"
0000    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa aaaaaaaa
0018    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa aaaaaaaa
0030    61 61 61 61 61 61 61 61                                                      aaaaaaaa                  ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }
        

        [Fact]
        public void When_Encode_56a_Columns3_Width8_Ascii1_Offset0_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 3;
            int width = 8;
            bool offset = false;
            bool ascii = true;
            
            var expected = @"
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa aaaaaaaa
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61    aaaaaaaa aaaaaaaa aaaaaaaa
61 61 61 61 61 61 61 61                                                      aaaaaaaa                  ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }
        

        [Fact]
        public void When_Encode_56a_Columns3_Width8_Ascii0_Offset1_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 3;
            int width = 8;
            bool offset = true;
            bool ascii = false;
            
            var expected = @"
0000    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
0018    61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
0030    61 61 61 61 61 61 61 61                                                  ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }
        

        [Fact]
        public void When_Encode_56a_Columns3_Width8_Ascii0_Offset0_Then_ok()
        {
            var data = Enumerable.Repeat((byte) 'a', 56).ToArray();
            int columns = 3;
            int width = 8;
            bool offset = false;
            bool ascii = false;
            
            var expected = @"
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61  61 61 61 61 61 61 61 61
61 61 61 61 61 61 61 61                                                  ".TrimStart();
            
            var result = HexDump.Format(data, width, columns, offset, ascii);
            var parsed = HexDump.Parse(result);
            var result2 = HexDump.Format(parsed, width, columns, offset, ascii);

            Assert.Equal(expected, result);
            Assert.Equal(expected, result2);
        }
    }
    
}
