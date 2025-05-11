using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(bool success, string token)> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Password == dto.Password);
        if (user != null)
        {
            // generate fake token for demo
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return (true, token);
        }
        return (false, null);
    }
}
