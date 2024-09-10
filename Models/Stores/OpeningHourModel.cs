using WebApp.Utils;

namespace WebApp.Models.Stores;

public class OpeningHourModel
{
    public Guid InternalId { get; set; } = Guid.NewGuid();
    public int Id { get; set; }
    public string? DayOfWeek { get; set; }
    public string? BeginAt { get; set; }
    public string? EndAt { get; set; }
    public int ScheduleType { get; set; }
    public int Sort { get; set; }

    public DateTime DateTimeBegin()
    {
        return DateTime.Parse($"{DateTimeUtils.Now().ToShortDateString()} {BeginAt}");
    }
    
    public DateTime DateTimeEnd()
    {
        return DateTime.Parse($"{DateTimeUtils.Now().ToShortDateString()} {EndAt}");
    }
}