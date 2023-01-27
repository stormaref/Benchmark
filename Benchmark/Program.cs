using Benchmark;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run(typeof(ConcurrentBagBenchmark).Assembly);