namespace LayeredArchitecture.Application.Helpers;
public class FormatHelper()
{
    public static string FormatTime(int minute)
    {
        var minTime = new TimeSpan(8,0,0);
        var time = minTime.Add(TimeSpan.FromMinutes(minute));
        return time.ToString(@"hh\:mm");
    }
}