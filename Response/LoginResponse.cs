namespace strivolabs_Assessment.Response
{
    public class LoginResponse
    {
        public string ServiceId { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}
