namespace IoC.Core;

public abstract class ClassInfo
{
    protected readonly Type Abstraction;
    protected readonly Type Implementation;
    protected ClassInfo(Type abstraction, Type implementation)
    {
        Abstraction = abstraction;
        Implementation = implementation;
    }
    
    public abstract object GetInstance();
}