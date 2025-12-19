using strivolabs_Assessment.Entities;
using strivolabs_Assessment.Response;

namespace strivolabs_Assessment.Repository
{
    public interface ISubscriptionService
    {
        Task Subscribe(int serviceId, string phoneNumber);
        Task Unsubscribe(int serviceId, string phoneNumber);
        Task<object> GetStatus(Service service, string phoneNumber);
    }
}
