using BenchmarkDotNet.Attributes;
using IoC.Core;

namespace IoC.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private interface ITransientAbstraction { }

    private interface ISingletonAbstraction { }
    
    private class TransientImplementation : ITransientAbstraction { }

    private class SingletonImplementation : ISingletonAbstraction { }
    
    private readonly Container _container;
    private readonly Type      _singletonAbstractionType = typeof(ISingletonAbstraction);
    private readonly Type      _transientAbstractionType = typeof(ITransientAbstraction);

    public Benchmarks()
    {
        _container = new Container();
        _container.RegisterSingleton<ISingletonAbstraction, SingletonImplementation>();
        _container.RegisterTransient<ITransientAbstraction, TransientImplementation>();

        _container.ResolveRequired<ISingletonAbstraction>();
    }

    #region Return Object
    
    [Benchmark]
    public void Resolve__________Object_Singleton()
    {
        _container.Resolve(_singletonAbstractionType);
    }
    
    [Benchmark]
    public void Resolve_Required_Object_Singleton()
    {
        _container.ResolveRequired(_singletonAbstractionType);
    }
    
    [Benchmark]
    public void Resolve__________Object_Transient()
    {
        _container.Resolve(_transientAbstractionType);
    }
    
    [Benchmark]
    public void Resolve_Required_Object_Transient()
    {
        _container.ResolveRequired(_transientAbstractionType);
    }
    
    #endregion

    #region Return Type
    
    [Benchmark]
    public void Resolve__________Type___Singleton()
    {
        _container.Resolve<ISingletonAbstraction>();
    }

    [Benchmark]
    public void Resolve_Required_Type___Singleton()
    {
        _container.ResolveRequired<ISingletonAbstraction>();
    }
    
    [Benchmark]
    public void Resolve__________Type___Transient()
    {
        _container.Resolve<ITransientAbstraction>();
    }

    [Benchmark]
    public void Resolve_Required_Type___Transient()
    {
        _container.ResolveRequired<ITransientAbstraction>();
    }
    
    #endregion
}