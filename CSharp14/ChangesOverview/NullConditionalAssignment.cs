namespace CSharp14.ChangesOverview;

internal class NullConditionalAssignment
{
    internal static void NullObject()
    {
        User? user = GetUserOrNull();

        // C# 13
        if (user is not null)
        {
            user.Country = "Alamakota";
        }

        // C# 14
        user?.Country = "Alamakota";
    }

    internal static void NullCollection()
    {
        User[]? users = Get2UsersOrNull();

        // C# 13
        if (users is not null)
        {
            users[0] = new User();
            users[1] = new User();
        }

        // C# 14
        users?[0] = new User();
        users?[1] = new User();
    }

    private static User? GetUserOrNull()
    {
        Random rnd = new();
        bool returnNull = rnd.Next(2) == 0;

        if (returnNull)
        {
            return null;
        }

        return new();
    }

    private static User[]? Get2UsersOrNull()
    {
        Random rnd = new();
        bool returnNull = rnd.Next(2) == 0;

        if (returnNull)
        {
            return null;
        }

        return [new(), new()];
    }
}

class User
{
    public string? Country { get; set; }
}
