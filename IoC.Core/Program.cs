using IoC.Core;


var container = new Container();


container.RegisterSingleton<IAnimal, Dog>();
container.RegisterSingleton<Name>();

var dog = container.ResolveRequired<IAnimal>();

Console.WriteLine(dog.GetType());

interface IAnimal {}

class Name
{
    public const string NAME = "BOB";
}
class Dog : IAnimal
{
    public Name Name;

    public Dog(Name name)
    {
        Name = name;
    }
}

