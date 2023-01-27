using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MemoryDiagnoser]
public class ConcurrentBagBenchmark
{
    private List<int> _list;
    private ConcurrentBag<int> _concurrentBag;

    [GlobalSetup]
    public void Setup()
    {
        _list = new();
        _concurrentBag = new();
    }

    [Benchmark]
    public void FillList()
    {
        for (int i = 0; i < 10000; i++)
        {
            _list.Add(i);
        }

        _list.Clear();
    }

    [Benchmark]
    public void FillConcurrentBag()
    {
        Parallel.For(0, 10000, i => _concurrentBag.Add(i));
        _concurrentBag.Clear();
    }

    [Benchmark]
    public void GetFromListFor()
    {
        _list = new(Enumerable.Range(0, 10000));
        for (int i = 0; i < _list.Count; i++)
        {
            var copy = _list[i];
        }
        _list.Clear();
    }

    [Benchmark]
    public void GetFromListForeach()
    {
        _list = new(Enumerable.Range(0, 10000));
        for (int i = 0; i < _list.Count; i++)
        {
            var copy = _list[i];
        }
        _list.Clear();
    }

    [Benchmark]
    public void GetFromListParallelFor()
    {
        _list = new(Enumerable.Range(0, 10000));
        Parallel.For(0, _list.Count, i =>
        {
            var copy = _list[i];
        });
        _list.Clear();
    }

    [Benchmark]
    public void GetFromListParallelForeach()
    {
        _list = new(Enumerable.Range(0, 10000));
        Parallel.ForEach(_list, i =>
        {
            var copy = i;
        });
        _list.Clear();
    }

    [Benchmark]
    public void GetFromConcurrentBag()
    {
        _concurrentBag = new(Enumerable.Range(0, 10000));
        Parallel.ForEach(_concurrentBag, i =>
        {
            var copy = i;
        });
        _concurrentBag.Clear();
    }
}