namespace CSharp14.ChangesOverview;

internal static class SimpleLambdaParametersWithModifiers
{
    delegate T Parse<T>(string text);
    delegate bool TryParse<T>(string text, out T result);

    internal static void Demo()
    {
        // Do parametrow wyrazen lambda mozna dodawac modyfikatory parametrow:
        // - scoped
        // - ref
        // - in
        // - out
        // - ref readonly
        // bez okreslania typu parametru.

        Parse<int> parse = (text) => Int32.Parse(text); // Nie ma żadnego problemu, bez zmiany.

        TryParse<int> tryParse1 = (string text, out int result) => Int32.TryParse(text, out result); // C# 13
        TryParse<int> tryParse2 = (text, out result) => Int32.TryParse(text, out result); // C# 14 - nie trzeba powtarzac typu.
    }
}
