namespace CSharp14.ChangesOverview;

internal class UserDefinedCompoundAssignment
{
    internal static void Demo()
    {
        Counter counter = new();
        Counter c = counter++; // A - wywoluje statyczne ++
        counter++; // B - wywoluje instancyjne ++ 
        counter += 5; // C - wywoluje instancyjne += 
        Counter c2 = counter += 5; // C - wywoluje instancyjne += i zwraca obiekt (sic!)
    }
}

class Counter
{
    public int Value;

    // A //
    // C# 13 - operator ++ jako metoda statyczna zwracajaca obiekt.
    public static Counter operator ++(Counter counter)
    {
        counter.Value = counter.Value + 1;
        return counter;
    }

    // B //
    // C# 14 - operator ++ jako metoda obiektu zwracajaca void.
    public void operator ++()
    {
        Value++;
    }

    // C //
    // C# 14 - mozliwosc samodzielnego zdefiniowania operatora +=
    // - metoda obiektu zwracajaca void
    public void operator +=(int x)
    {
        Value += x;
    }
}
