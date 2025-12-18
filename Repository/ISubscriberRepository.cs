using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repository
{
    public interface ISubscriberRepository
    {
        Task<Subscriber?> Get(int serviceId, string phoneNumber);
        Task Add(Subscriber subscriber);
        Task Update(Subscriber subscriber);
    }
}
