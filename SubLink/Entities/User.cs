namespace SubLink.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Server { get; set; }
    public string? TelegramUsername { get; set; }
    public string? Email { get; set; }

    public List<UserRequestLog> UserRequestLogs { get; set; }

}