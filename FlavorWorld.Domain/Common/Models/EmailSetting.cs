namespace FlavorWorld.Domain.Models;

public class EmailSetting
{
    public string ToEmail { get; set; }
    public string Message { get; set; }
    public DateTime MessageDate { get; set; } = DateTime.Now;
}