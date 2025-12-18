using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Repositories;

public interface IServiceRepository
{
    Task<Service> GetServiceById(string  serviceId);
}
