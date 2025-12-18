using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repository
{
    public interface IServiceTokenRepository
    {
        Task<ServiceToken?> GetValidToken(int serviceId, string token);
        Task<ServiceToken?> GetActiveToken(int serviceId);
        Task AddAsync(ServiceToken token);
    }
}
