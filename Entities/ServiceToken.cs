namespace strivolabs_Assessment.Entities
{
    public class ServiceToken
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service service { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}