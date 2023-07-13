using System.Runtime.CompilerServices;

public class Programer : IWorkWithPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    /*=====Interface Realization======*/
    public string GetName { get => Name;}
    public int GetAge { get => Age;}
    public string GetPosition { get => Position;  }
}

public class Tester : IWorkWithPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    /*=====Interface Realization======*/
    public string GetName { get =>Name ;  }
    public int GetAge { get => Age; }
    public string GetPosition { get =>Position ;  }
}

public class CreateTesterFactory : MainFactory
{
    private readonly string NameInitializer;
    private readonly int AgeInitializer;
    private readonly string PositionInitializer;
    public CreateTesterFactory (string Name, int Age, string Position)
    {
        NameInitializer = Name;
        AgeInitializer = Age;
        PositionInitializer = Position;
    }
    public override IWorkWithPerson CreateInstance()
    {
        var testerInstance = new Tester
        {
            Name = NameInitializer,
            Age = AgeInitializer,
            Position = PositionInitializer
        };
        return testerInstance;
    }
}

public class CreateProgramerFactory : MainFactory
{
    private readonly string NameInitializer;
    private readonly int AgeInitializer;
    private readonly string PositionInitializer;
    public CreateProgramerFactory (string Name, int Age, string Position)
    {
        NameInitializer = Name;
        AgeInitializer = Age;
        PositionInitializer = Position;
    }
    public override IWorkWithPerson CreateInstance()
    {
        var progerInstance = new Programer
        {
            Name = NameInitializer,
            Age = AgeInitializer,
            Position = PositionInitializer
        };
        return progerInstance;
    }
}

public interface IWorkWithPerson
{
    string GetName { get;}
    int GetAge { get;}
    string GetPosition { get;}

}

public abstract class MainFactory
{
    public abstract IWorkWithPerson CreateInstance();
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Чтобы создать Програмиста нажмите 1 для Тестировщика нажмите 2");
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.F1)
        {
            Console.WriteLine("Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Возраст");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Должность");
            string position = Console.ReadLine();
            MainFactory factory = new CreateProgramerFactory(name,age,position);
            var progerInfo = factory.CreateInstance();
            Console.WriteLine($"Name - {progerInfo.GetName} Position - {progerInfo.GetPosition} Age - {progerInfo.GetAge}");
        }
        else if (key == ConsoleKey.F2)
        {
            Console.WriteLine("Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Возраст");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Должность");
            string position = Console.ReadLine();
            MainFactory factory = new CreateTesterFactory(name, age, position);
            var progerInfo = factory.CreateInstance();
            Console.WriteLine($"Name - {progerInfo.GetName} Position - {progerInfo.GetPosition} Age - {progerInfo.GetAge}");
        }
      
    }
}