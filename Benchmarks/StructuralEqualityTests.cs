using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FsTests;

namespace Benchmarks
{
    [RPlotExporter, SimpleJob(RuntimeMoniker.NetCoreApp31), RankColumn, MemoryDiagnoser, GcServer(true), GcConcurrent(true)]
    public class StructuralEqualityTests
    {
        [Benchmark]
        public void FsComparer()
        {
            StructuralEquality.compare(StructuralEquality.firstValue, StructuralEquality.secondValue);
        }
        
        [Benchmark]
        public void StructEqualsComparer()
        {
            var result = Selection.FirstValue.Equals(Selection.SecondValue);
        }
        
        [Benchmark]
        public void StructHashComparer()
        {
            var result = Selection.FirstValue.GetHashCode() == Selection.SecondValue.GetHashCode();
        }
    }

    struct Selection
    {
        private Selection(int a, double d, bool isEnabled)
        {
            AmericanOdds = a;
            DecimalOdds = d;
            IsEnabled = isEnabled;
        }
        
        public int AmericanOdds;
        public double DecimalOdds;
        public bool IsEnabled;
        
        public static readonly Selection FirstValue = new Selection(420, 5.2, true);
        public static readonly Selection SecondValue = new Selection(420, 5.2, true);
        
        public static bool StructHashComparer() 
            => FirstValue.GetHashCode() == SecondValue.GetHashCode();
        
        public static bool StructEqualsComparer 
            => FirstValue.Equals(SecondValue);
    }
}