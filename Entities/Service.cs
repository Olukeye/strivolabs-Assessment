namespace strivolabs_Assessment.Entities;

public class Service
{
    public int Id { get; set; }
    public string ServiceId { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<ServiceToken> Tokens { get; set; } = new List<ServiceToken>();
    public ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
}
