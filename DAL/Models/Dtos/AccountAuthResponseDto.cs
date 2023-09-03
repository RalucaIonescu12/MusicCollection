namespace DAL.Models.DTOs
{
    public class AccountAuthResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }

        public AccountAuthResponseDto(Account account , string token)
        {
            Id = account.Id;
            Name = account.Name;
            Email = account.Email;
            Token = token;
        }
    }
}
