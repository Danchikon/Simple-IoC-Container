namespace IoC.Core;

public sealed class Container
{
    private readonly Dictionary<Type, Implementation> _implementations = new();

    #region Register Singleton
    
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
        var singleton = new Singleton(implementation, this)!;
        _implementations.TryAdd(abstraction, singleton);
    }
    
    #endregion

    #region Register Transient
    
    public void RegisterTransient<TAbstraction, TImplementation>() where TImplementation : class, TAbstraction
    {
        RegisterTransient(typeof(TAbstraction), typeof(TImplementation));
    }
    
    public void RegisterTransient<TImplementation>() where TImplementation : class
    {
        RegisterTransient(typeof(TImplementation), typeof(TImplementation));
    }
    
    public void RegisterTransient(Type abstraction, Type implementation) 
    {
        var singleton = new Transient(implementation, this)!;
        _implementations.TryAdd(abstraction, singleton);
    }
    
    #endregion

    #region Resolve

    public TAbstraction? Resolve<TAbstraction>()
    {
        return (TAbstraction?)Resolve(typeof(TAbstraction));
    }
    
    public object? Resolve(Type abstraction)
    {
        var service = _implementations.GetValueOrDefault(abstraction);
        return service?.GetInstance();
    }
    
    public TAbstraction ResolveRequired<TAbstraction>()
    {
        return (TAbstraction)ResolveRequired(typeof(TAbstraction));
    }

    public object ResolveRequired(Type abstraction)
    {
        var instance = Resolve(abstraction);

        return instance ?? throw new Exception("The type must be registered in the container");
    }

    #endregion
}