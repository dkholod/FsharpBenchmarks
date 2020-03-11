using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FsTests;

namespace Benchmarks
{
    [RPlotExporter, SimpleJob(RuntimeMoniker.NetCoreApp31), RankColumn, MemoryDiagnoser, GcServer(true), GcConcurrent(true)]
    public class InterestingTests
    {
        // [Benchmark]
        // public void Soccer()
        // {
        //     InterestingToKnow.branchToString(InterestingToKnow.Branch.Soccer);
        // }
        //
        // [Benchmark]
        // public void Greyhounds()
        // {
        //     InterestingToKnow.branchToString(InterestingToKnow.Branch.Greyhounds);
        // }
        //
        // [Benchmark]
        // public void Sprintf()
        // {
        //     InterestingToKnow.concat("Number of leagues", 5);
        // }
        //
        // [Benchmark]
        // public void Format()
        // {
        //     InterestingToKnow.format("Number of leagues", 5);
        // }
        
        [Benchmark]
        public void NullCheck()
        {
            InterestingToKnow.nullCheck<TestClass>(null);
        }
        
        [Benchmark]
        public void DefaultCheck()
        {
            InterestingToKnow.isDefaulf<TestClass>(null);
        }
        
        [Benchmark]
        public void MatchCheck()
        {
            InterestingToKnow.nullCheckMatch<TestClass>(null);
        }
        
        [Benchmark]
        public void RefCheck()
        {
            InterestingToKnow.nullCheckRefEqls<TestClass>(null);
        }
    }

    public class TestClass
    {
        public int Bag { get; set; }
    }
}