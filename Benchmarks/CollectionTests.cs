using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31), RankColumn, MemoryDiagnoser, GcServer(true), GcConcurrent(true)]
    public class CollectionTests
    {
        List<int> _testList;

        public CollectionTests(List<int> testList)
        {
            _testList = testList;
        }

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public void ArrayFilterItems()
        {
            FsTests.Collections.arrayFilterItems();
        }

        [Benchmark]
        public void SetFilterItems()
        {
            FsTests.Collections.setFilterItems();
        }

        [Benchmark]
        public void ListFilterItems()
        {
            FsTests.Collections.listFilter500kItems();
        }

        [Benchmark]
        public void SetToArrayFilter500kItems()
        {
            FsTests.Collections.setToArrayFilter500kItems();
        }
    }
}