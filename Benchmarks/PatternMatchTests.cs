using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FsTests;

namespace Benchmarks
{
    [RPlotExporter, SimpleJob(RuntimeMoniker.NetCoreApp31), RankColumn, MemoryDiagnoser, GcServer(true), GcConcurrent(true)]
    public class PatternMatchTests
    {
        private PatternMathc.Line otherLine = new PatternMathc.Line("other", 1, 3);
        private PatternMathc.Line overLine = new PatternMathc.Line("over", 1, 3);
        
        [Benchmark]
        public void Constant()
        {
            PatternMathc.getBranchEventType(PatternMathc.Branch.Boxing);
        }

        [Benchmark]
        public void If()
        {
            PatternMathc.getBranchEventTypeIFs(PatternMathc.Branch.Boxing);
        }

        [Benchmark]
        public void Conditions()
        {
            PatternMathc.getBranchEventTypeConditional(PatternMathc.Branch.Boxing);
        }
        
        [Benchmark]
        public void Complete()
        {
            PatternMathc.getPoints(otherLine);
        }
        
        [Benchmark]
        public void Partial()
        {
            PatternMathc.getPointsPartial(otherLine);
        }
        
        [Benchmark]
        public void Over()
        {
            PatternMathc.getOverPoints(overLine);
        }
    }
}