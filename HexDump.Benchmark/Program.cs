using BenchmarkDotNet.Running;

namespace HexDump.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FormatBenchmark>();
        }
    }
}