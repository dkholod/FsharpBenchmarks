using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks
{
    enum ElementsCount
    {
        Ten,
        Thousand,
        Million
    }
    
    [RPlotExporter, SimpleJob(RuntimeMoniker.NetCoreApp31), RankColumn, MemoryDiagnoser, GcServer(true), GcConcurrent(true)]
    public class CollectionTests
    {
        ElementsCount elementsCount = ElementsCount.Million;

        [Benchmark]
        public void Array()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.arrayTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.arrayTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.arrayTest1M();
                    break;
            }
        }
        
        [Benchmark]
        public void NsArr()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.nessosOnArrayTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.nessosOnArrayTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.nessosOnArrayTest1M();
                    break;
            }
        }
        
        [Benchmark]
        public void LinqArr()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.linqOnArrayTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.linqOnArrayTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.linqOnArrayTest1M();
                    break;
            }
        }

        [Benchmark]
        public void FsList()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.listTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.listTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.listTest1M();
                    break;
            }
        }

        [Benchmark]
        public void FsSeq()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.seqTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.seqTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.seqTest1M();
                    break;
            }
        }
        
        [Benchmark]
        public void NsSeq()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.nessosOnSeqTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.nessosOnSeqTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.nessosOnSeqTest1M();
                    break;
            }
        }

        [Benchmark]
        public void LinqSeq()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.linqOnSeqTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.linqOnSeqTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.linqOnSeqTest1M();
                    break;
            }
        }
        
        [Benchmark]
        public void ArrOfSeq()
        {
            switch (elementsCount)
            {
                case ElementsCount.Ten:
                    FsTests.Collections.seqToArrayTest10();
                    break;
                case ElementsCount.Thousand:
                    FsTests.Collections.seqToArrayTest1K();
                    break;
                case ElementsCount.Million:
                    FsTests.Collections.seqToArrayTest1M();
                    break;
            }
        }
    }
}