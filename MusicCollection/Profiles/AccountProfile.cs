using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using AutoMapper;
namespace MusicCollection.Profiles
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountCreateDto>();
            CreateMap<Account, AccountDto>();
            CreateMap< AccountCreateDto, Account>();
        }
    }
}
