namespace CSharp14.ChangesOverview;

// # More partial members #

// # A #
// - Partial constructor 
// - Primary constructor
// - Constructor initializer: this()

public partial class Person() // Primary konstruktor tylko w jednej czesci
{
    private string _name = string.Empty;

    // Deklaracja konstruktora.
    public partial Person(string name);
}

public partial class Person
{
    // Implementacja konstruktora.
    public partial Person(string name) : this() // this tylko w implementacji
    {
        _name = name;
    }
}

// # B #
// - Partial constructor 
// - Constructor initializer: base()

public partial class Employee : Person
{
    private Guid _id;

    // Deklaracja konstruktora.
    public partial Employee(string name, Guid id);
}

public partial class Employee
{
    // Implementacja konstruktora.

    public partial Employee(string name, Guid id) : base(name) // base tylko w implementacji
    {
        _id = id;
    }
}

// # C #
// - Partial event

public partial class Notifier
{
    // Deklaracja zdarzenia.
    public partial event EventHandler? Notified;
}

public partial class Notifier
{
    private EventHandler? handlers;

    // Implementacja zdarzenia.
    public partial event EventHandler? Notified
    {
        add => handlers += value; // implementacja musi posiadac add 
        remove => handlers -= value; // implementacja musi posiadac remove
    }

    public void Notify() => handlers?.Invoke(this, EventArgs.Empty);
}
