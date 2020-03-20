using BenchmarkDotNet.Running;
using FsTests;

namespace Benchmarks
{
    static class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run<CollectionTests>();
            //FsTests.TailOptimization.test();
        }
    }
}