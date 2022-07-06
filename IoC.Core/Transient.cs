namespace IoC.Core;

public class Transient : Implementation
{
    private readonly Container _container;

    public Transient(Type implementation, Container container) : base(implementation)
    {
        _container = container;
    }
    public override object GetInstance()
    {
        return CreateInstance();
    }

    private object CreateInstance()
    {
        if (ConstructorParametersTypes.Count == 0)
            return Activator.CreateInstance(Type)!;

        var parametersInstances = new HashSet<object>();
        
        foreach (var parameter in ConstructorParametersTypes)
        {
            parametersInstances.Add(_container.ResolveRequired(parameter));
        }

        return Activator.CreateInstance(Type, parametersInstances.ToArray())!;;
    }
}