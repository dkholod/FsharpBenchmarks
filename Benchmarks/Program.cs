using BenchmarkDotNet.Running;

namespace Benchmarks
{
    static class Program
    {
        static void Main(string[] _)
        {
            //BenchmarkRunner.Run<StructuralEqualityTests>();
            FsTests.TailOptimization.test();
        }
    }
}