using BenchmarkDotNet.Running;
using IoC.Benchmarks;

var summary = BenchmarkRunner.Run<Benchmarks>();