namespace IoC.Core;

public abstract class Implementation
{
    protected readonly Type Type;
    protected readonly HashSet<Type> ConstructorParametersTypes = new();
    
    protected Implementation(Type type)
    {
        Type = type;
        var constructorInfo = Type.GetConstructors().First();
        var parameters = constructorInfo.GetParameters();

        foreach (var parameter in parameters)
        {
            ConstructorParametersTypes.Add(parameter.ParameterType);
        }
    }
    
    public abstract object GetInstance();
}