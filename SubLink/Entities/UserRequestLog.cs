namespace SubLink.Entities;

public class UserRequestLog
{
    public User User { get; set; }
    public Guid UserId { get; set; }

    public DateTime DateTime { get; set; }

    public InternetServiceProvider ServiceProvider { get; set; }
    public int ServiceProviderId { get; set; }
}