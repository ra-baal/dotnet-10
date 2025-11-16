namespace CSharp14.ChangesOverview;

internal static class UnboundGenericTypesAndNameof
{
    internal static void Demo()
    {
        string nameOfList1 = nameof(List<int>); // C# 13
        string nameOfList2 = nameof(List<>); // C# 14

        Console.WriteLine(nameOfList1); // List
        Console.WriteLine(nameOfList2); // List
    }
}
