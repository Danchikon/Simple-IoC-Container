
using BenchmarkDotNet.Attributes;
using IoC.Core;

namespace IoC.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private readonly Container _container;

    public Benchmarks()
    {
        _container = new Container();
        _container.RegisterSingleton<IBenchmarkService, BenchmarkServiceImplementation>();
    }
    
    [Benchmark]
    public void ResolveRequiredSingleton()
    {
        _container.ResolveRequired<IBenchmarkService>();
    }
    
    [Benchmark]
    public void ResolveSingleton()
    {
        _container.Resolve<IBenchmarkService>();
    }

    // [Benchmark]
    // public void AddSingletonService()
    // {
    //     _container.AddSingleton<IBenchmarkService, BenchmarkServiceImplementation>();
    // }
}