using strivolabs_Assessment.DTOs;
using strivolabs_Assessment.Response;

namespace strivolabs_Assessment.Repository
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);

    }
}
