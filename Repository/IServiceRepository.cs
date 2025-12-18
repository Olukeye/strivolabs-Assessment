using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repository
{
    public interface IServiceRepository
    {
        Task<Service?> GetByServiceId(string serviceId);

    }
}
