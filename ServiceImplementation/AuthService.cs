using strivolabs_Assessment.DTOs;
using strivolabs_Assessment.Entities;
using strivolabs_Assessment.Repository;
using strivolabs_Assessment.Response;

namespace strivolabs_Assessment.ServiceImplementation
{
    public class AuthService : IAuthService
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IServiceTokenRepository _tokenRepo;
        private readonly IConfiguration _config;

        public AuthService(
            IServiceRepository serviceRepo,
            IServiceTokenRepository tokenRepo,
            IConfiguration config)
        {
            _serviceRepo = serviceRepo;
            _tokenRepo = tokenRepo;
            _config = config;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var service = await _serviceRepo.GetByServiceId(request.ServiceId)
                ?? throw new UnauthorizedAccessException("Invalid credentials");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, service.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            var existingToken = await _tokenRepo.GetActiveToken(service.Id);
            if (existingToken != null)
            {
                return new LoginResponse
                {
                    Token = existingToken.Token,
                    ExpiresAt = existingToken.ExpiresAt
                };
            }

            var expiry = _config.GetValue<int>("TokenSettings:ExpiryHours");

            var token = new ServiceToken
            {
                ServiceId = service.Id,
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddHours(expiry)
            };

            await _tokenRepo.AddAsync(token);

            return new LoginResponse
            {
                Token = token.Token,
                ExpiresAt = token.ExpiresAt
            };
        }

    }
}
