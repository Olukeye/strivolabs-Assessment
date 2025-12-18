using Microsoft.EntityFrameworkCore;
using strivolabs_Assessment.Data;
using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repository
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly AppDbContext _db;

        public ServiceRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Service?> GetByServiceId(string serviceId)
        {
            return await _db.Services
                .Include(s => s.Tokens)
                .FirstOrDefaultAsync(s => s.ServiceId == serviceId);
        }
    }
}
