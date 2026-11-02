namespace tecBackend.Utils;

public static class BishkekClock
{
    public static DateTime Now => DateTime.SpecifyKind(DateTime.UtcNow.AddHours(6), DateTimeKind.Unspecified);
}
