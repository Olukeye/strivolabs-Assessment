using Microsoft.EntityFrameworkCore;
using strivolabs_Assessment.Data;
using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repository
{
    public class SubscriberRepository : ISubscriberRepository
    {

        private readonly AppDbContext _db;

        public SubscriberRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Subscriber subscriber)
        {
            _db.Subscribers.Add(subscriber);
            await _db.SaveChangesAsync();
        }

        public async Task<Subscriber?> Get(int serviceId, string phoneNumber)
        {

            return await _db.Subscribers
                .FirstOrDefaultAsync(s =>
                    s.ServiceId == serviceId &&
                    s.PhoneNumber == phoneNumber);
        }

        public async Task Update(Subscriber subscriber)
        {
            _db.Subscribers.Update(subscriber);
            await _db.SaveChangesAsync();
        }
    }
}
