using Microsoft.EntityFrameworkCore;
using strivolabs_Assessment.Data;
using strivolabs_Assessment.Entities;
using strivolabs_Assessment.Repository;

namespace strivolabs_Assessment.ServiceRepositories
{
    public class ServiceTokenRepository: IServiceTokenRepository
    {
        private readonly AppDbContext _db;

        public ServiceTokenRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceToken?> GetValidToken(int serviceId, string token)
        {
            return await _db.ServiceTokens.FirstOrDefaultAsync(t =>
                t.ServiceId == serviceId &&
                t.Token == token &&
                t.ExpiresAt > DateTime.UtcNow);
        }

        public async Task<ServiceToken?> GetActiveToken(int serviceId)
        {
            return await _db.ServiceTokens.FirstOrDefaultAsync(t =>
                t.ServiceId == serviceId &&
                t.ExpiresAt > DateTime.UtcNow);
        }

        public async Task AddAsync(ServiceToken token)
        {
            _db.ServiceTokens.Add(token);
            await _db.SaveChangesAsync();
        }
    }
}
