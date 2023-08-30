using MusicCollection.Models;

namespace MusicCollection.Helpers.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Account  account);
        public Guid ValidateJwtToken(string token);
    }
}
