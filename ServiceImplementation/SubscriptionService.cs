using strivolabs_Assessment.Entities;
using strivolabs_Assessment.Enums;
using strivolabs_Assessment.Exceptions;
using strivolabs_Assessment.Repository;
using strivolabs_Assessment.Response;

namespace strivolabs_Assessment.ServiceImplementation
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriberRepository _subscriberRepo;

        public SubscriptionService(ISubscriberRepository subscriberRepo)
        {
            _subscriberRepo = subscriberRepo;
        }

        public async Task Subscribe(int serviceId, string phoneNumber)
        {
            var subscriber = await _subscriberRepo.Get(serviceId, phoneNumber);

            if (subscriber != null && subscriber.Status == SubscriptionStatus.SUBSCRIBED)
                throw new ApiGenericException("User already subscribed");

            if (subscriber == null)
            {
                subscriber = new Subscriber
                {
                    ServiceId = serviceId,
                    PhoneNumber = phoneNumber,
                    Status = SubscriptionStatus.SUBSCRIBED,
                    SubscribedAt = DateTime.UtcNow
                };

                await _subscriberRepo.Add(subscriber);

                return;
            }

            subscriber.Status = SubscriptionStatus.SUBSCRIBED;
            subscriber.SubscribedAt = DateTime.UtcNow;
            subscriber.UnsubscribedAt = null;

            await _subscriberRepo.Update(subscriber);

        }

        public async Task Unsubscribe(int serviceId, string phoneNumber)
        {
            var subscriber = await _subscriberRepo.Get(serviceId, phoneNumber);

            subscriber.Status = SubscriptionStatus.UNSUBSCRIBED;
            subscriber.UnsubscribedAt = DateTime.UtcNow;

            await _subscriberRepo.Update(subscriber);
        }

        public async Task<object> GetStatus(Service service, string phoneNumber)
        {
            var subscriber = await _subscriberRepo.Get(service.Id, phoneNumber);

            if (subscriber == null)
                throw new KeyNotFoundException("User not found");

            return new
            {
                status = subscriber.Status.ToString(),
                subscriber.SubscribedAt,
                subscriber.UnsubscribedAt
            };
        }
    }
}
