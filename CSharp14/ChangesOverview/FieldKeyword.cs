namespace CSharp14.ChangesOverview;

internal class Notification0
{
    public string Message { get; set; }
}

internal class Notification1
{
    private string _msg;
    public string Message
    {
        get => _msg;
        set => _msg = value ?? throw new ArgumentNullException(nameof(value));
    }
}

internal class Notification2
{
    public string Message
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    }
}
