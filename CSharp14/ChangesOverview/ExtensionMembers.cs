namespace CSharp14.ChangesOverview;

internal static class ExtensionMembers
{
    internal static void Demo()
    {
        List<int> A = [];
        List<int> B = [1, 2, 3];
        List<int> C = [40, 50, 60];
        A.Print("A");
        B.Print("B");
        C.Print("C");

        Console.WriteLine();
        Console.WriteLine(A.IsEmpty);
        Console.WriteLine(B.IsEmpty);
        Console.WriteLine(C.IsEmpty);
        Console.WriteLine();
        Console.WriteLine(A.None(1));
        Console.WriteLine(B.None(1));
        Console.WriteLine(C.None(1));
        Console.WriteLine();

        IEnumerable<int> D = List<int>.Identity;
        D.Print("D");

        IEnumerable<int> combined = List<int>.Combine(B, C);
        combined.Print("combined");

        IEnumerable<int> E = B + C;
        E.Print("E");
    }
}

internal static class EnumerableExtensions
{
    // this
    internal static void Print<TSource>(this IEnumerable<TSource> enumerable, string label = "")
    {
        ArgumentNullException.ThrowIfNull(enumerable);

        Console.Write($"{label}: ");

        foreach (var item in enumerable)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("");
    }

    // blok extension dla instancji
    extension<TSource>(IEnumerable<TSource> source) // elementy rozszerzajace dla instancji
    {
        // Extension property
        internal bool IsEmpty => !source.Any();

        // Extension method:
        internal bool None(TSource element) 
        { 
            return !source.Contains(element);
        }
    }

    // blok extension dla typu
    extension<TSource>(IEnumerable<TSource>) // statyczne elementy rozszerzajace dla typu
    {
        // static extension method
        internal static IEnumerable<TSource> Combine(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            ArgumentNullException.ThrowIfNull(first);
            ArgumentNullException.ThrowIfNull(second);

            foreach (var item in first)
                yield return item;

            foreach (var item in second)
                yield return item;
        }

        // static extension property
        internal static IEnumerable<TSource> Identity =>
            Enumerable.Empty<TSource>();

        // static user defined operator
        public static IEnumerable<TSource> operator +(IEnumerable<TSource> left, IEnumerable<TSource> right) =>
            left.Concat(right);
    }
}
