
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace HexDump.Benchmark
{
    // [ClrJob, CoreJob, MonoJob]
    //[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[SimpleJob(RuntimeMoniker.CoreRt30)]
    //[SimpleJob(RuntimeMoniker.Mono)]
    [RPlotExporter]

    public class FormatBenchmark
    {
        private string _dump;

        [Params(10, 100, 1000)] 
        public int _len;
        
        [GlobalSetup]
        public void Setup()
        {
            _dump = HexDump.Format(new byte[_len]);
        }

        [Benchmark]
        public void Parse()
        {
            HexDump.Parse(_dump);
        }
        [Benchmark]
        public void ParseLookup()
        {
            HexDump.ParseLookup(_dump);
        }
        [Benchmark]
        public void ParseDic()
        {
            HexDump.ParseDic(_dump);
        }
        [Benchmark]
        public void ParseConvert()
        {
            HexDump.ParseConvert(_dump);
        }

        [Benchmark]
        public void ParseRegex()
        {
            HexDump.ParseRegex(_dump);
        }

    }
}