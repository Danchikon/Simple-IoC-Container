using BindingFlags = System.Reflection.BindingFlags;

namespace IoC.Core;

public class SingletonClass : ClassInfo
{
    private object? _serviceInstance;
    private readonly Container _container;

    public SingletonClass(Type abstraction, Type implementation, Container container) 
        : base(abstraction, implementation)
    {
        _container = container;
    }
    public override object GetInstance()
    {
        return _serviceInstance ?? CreateInstance();
    }

    private object CreateInstance()
    {
        var constructorInfos = Implementation.GetConstructors().First();
        var parameters = constructorInfos.GetParameters();

        var parametersInstances = new List<object>();
        
        foreach (var parameter in parameters)
        {
            parametersInstances.Add(_container.ResolveRequired(parameter.ParameterType));
        }
        
        _serviceInstance = Activator.CreateInstance(Implementation, parametersInstances.ToArray())!;

        return _serviceInstance;
    }
}