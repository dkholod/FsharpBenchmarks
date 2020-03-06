using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FsTests;

namespace Benchmarks
{
    [RPlotExporter, SimpleJob(RuntimeMoniker.NetCoreApp31), RankColumn, MemoryDiagnoser, GcServer(true), GcConcurrent(true)]
    public class InlineTests
    {
        [Benchmark]
        public void AddNumbers()
        {
            InlineFunctions.addNumbers(1, 3);
        }
        
        [Benchmark]
        public void AddFromCs()
        {
            InlineFunctions.add<int,int,int>(1, 2);
        }
    }
}