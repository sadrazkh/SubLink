namespace SubLink.Entities
{
    public class CleanIp
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public bool Active { get; set; }

        public InternetServiceProvider InternetServiceProvider { get; set; }
        public int InternetServiceProviderId { get; set; }
    }
}
