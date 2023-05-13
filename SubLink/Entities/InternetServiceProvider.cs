namespace SubLink.Entities;

public class InternetServiceProvider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public List<CleanIp> CleanIps { get; set; }
}