namespace IoC.Core;

public class Singleton : Implementation
{
    private object? _serviceInstance;
    private readonly Container _container;

    public Singleton(Type implementation, Container container) : base(implementation)
    {
        _container = container;
    }
    public override object GetInstance()
    {
        return _serviceInstance ?? CreateInstance();
    }

    private object CreateInstance()
    {
        if (ConstructorParametersTypes.Count == 0)
            return _serviceInstance = Activator.CreateInstance(Type)!;
        
        var parametersInstances = new HashSet<object>();
        
        foreach (var parameter in ConstructorParametersTypes)
        {
            parametersInstances.Add(_container.ResolveRequired(parameter));
        }
        
        return _serviceInstance = Activator.CreateInstance(Type, parametersInstances.ToArray())!;
    }
}