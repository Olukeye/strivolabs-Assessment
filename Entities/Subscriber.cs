using strivolabs_Assessment.Enums;

namespace strivolabs_Assessment.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public SubscriptionStatus Status { get; set; }

        public DateTime? SubscribedAt { get; set; }
        public DateTime? UnsubscribedAt { get; set; }
    }
}