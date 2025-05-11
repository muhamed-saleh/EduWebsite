public interface IAuthService
{
    Task<(bool success, string token)> LoginAsync(LoginDto dto);
}
