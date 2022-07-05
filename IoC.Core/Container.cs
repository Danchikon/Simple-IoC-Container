namespace IoC.Core;

public sealed class Container
{
    private readonly Dictionary<Type, ClassInfo> _services = new();

    public void RegisterSingleton<TAbstraction, TImplementation>() where TImplementation : class, TAbstraction
    {
        RegisterSingleton(typeof(TAbstraction), typeof(TImplementation));
    }
    
    public void RegisterSingleton<TImplementation>() where TImplementation : class
    {
        RegisterSingleton(typeof(TImplementation), typeof(TImplementation));
    }
    
    public void RegisterSingleton(Type abstraction, Type implementation) 
    {
        var singleton = new SingletonClass(abstraction, implementation, this)!;
        _services.TryAdd(abstraction, singleton);
    }
    
    // public void AddTransient<TService, TImplementation>() where TImplementation : TService
    // {
    //     _services.TryAdd(typeof(TService), typeof(TImplementation));
    // }
    
    public TAbstraction? Resolve<TAbstraction>()
    {
        return (TAbstraction?)Resolve(typeof(TAbstraction));
    }
    
    public object? Resolve(Type abstraction)
    {
        var service = _services.GetValueOrDefault(abstraction);
        return service?.GetInstance();
    }
    
    public TAbstraction ResolveRequired<TAbstraction>()
    {
        return (TAbstraction)ResolveRequired(typeof(TAbstraction));
    }

    public object ResolveRequired(Type abstraction)
    {
        var instance = Resolve(abstraction);

        return instance ?? throw new Exception("The class must be registered in the container");
    }
}