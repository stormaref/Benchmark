using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark;

public class DictionaryBenchmark
{
    private Dictionary<int, int> _dictionary;
    private ImmutableDictionary<int, int> _immutableDictionary;

    [GlobalSetup]
    public void Setup()
    {
        _dictionary = new Dictionary<int, int>();
        for (int i = 0; i < 1000; i++)
        {
            _dictionary[i] = i;
        }
        _immutableDictionary = _dictionary.ToImmutableDictionary();
    }

    [Benchmark]
    public void GetFromDictionary()
    {
        for (int i = 0; i < 1000; i++)
        {
            var number = _dictionary[GetRandom()];
        }
    }

    [Benchmark]
    public void GetFromImmutableDictionary()
    {
        for (int i = 0; i < 1000; i++)
        {
            var number = _immutableDictionary[GetRandom()];
        }
    }

    private static int GetRandom()
    {
        return Random.Shared.Next(0, 1000);
    }
}