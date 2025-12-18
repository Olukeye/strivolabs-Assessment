using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repository
{
    public interface ISubscriptionService
    {
        Task Subscribe(int serviceId, string phoneNumber);
        Task Unsubscribe(Service service, string phoneNumber);
        Task<object> GetStatus(Service service, string phoneNumber);
    }
}
