namespace CSharp14.ChangesOverview;

internal static class ImplicitSpanConversion1
{
    internal static void Example() // E[] -> Span<E>
    {
        int[] numbers = [1, 2, 3];
        numbers.AsSpan().DoSth(); // C# 13
        numbers.DoSth(); // C# 14 – niejawna konwersja int[] do Span<int>
    }

    static void DoSth(this Span<int> span) { }
}

internal static class ImplicitSpanConversion2
{
    internal static void Example() // E[] -> ReadOnlySpan<U> where E : U
    {
        string[] names = ["Adam", "Ewa"];
        new ReadOnlySpan<object>(names).DoSth(); // C# 13
        names.DoSth(); // C# 14 – niejawna konwersja string[] do ReadOnlySpan<object>
    }

    static void DoSth(this ReadOnlySpan<object> span) { }

}

internal static class ImplicitSpanConversion3
{
    internal static void Example() // Span<E> -> ReadOnlySpan<U> where E : U
    {
        Span<Animal> animals = [new(), new()];
        new ReadOnlySpan<object>(animals.ToArray()).DoSth(); // C# 13
        animals.DoSth(); // C# 14 – niejawna konwersja Span<Animal> do ReadOnlySpan<object>
    }

    class Animal();
    static void DoSth(this ReadOnlySpan<object> span) { }
}

internal static class ImplicitSpanConversion4
{
    internal static void Example()  // ReadOnlySpan<E> -> ReadOnlySpan<U> where E : U
    {
        ReadOnlySpan<Dog> dogs = [new(), new()];
        new ReadOnlySpan<Animal>(dogs.ToArray()).DoSth(); // C# 13
        dogs.DoSth(); // C# 14 – niejawna konwersja ReadOnlySpan<Dog> do ReadOnlySpan<Animal>
    }

    class Animal();
    class Dog() : Animal;
    static void DoSth(this ReadOnlySpan<Animal> span) { }
}

internal static class ImplicitSpanConversion5
{  
    internal static void Example() // string -> ReadOnlySpan<char>
    {
        string text = "hello";
        text.AsSpan().DoSth(); // C# 13
        text.DoSth(); // C# 14 – niejawna konwersja string do ReadOnlySpan<char>
    }

    internal static void DoSth(this ReadOnlySpan<char> span) { }
}
