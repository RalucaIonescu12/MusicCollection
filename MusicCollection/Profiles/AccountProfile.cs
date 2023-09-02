using DAL.Models;
using DAL.Models.Dtos;
using AutoMapper;
using DAL.Models.DTOs;

namespace MusicCollection.Profiles
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountCreateDto>();
            CreateMap<Account, AccountDto>();
            CreateMap< AccountDto, Account>();
            CreateMap< AccountCreateDto, Account>();
            CreateMap<AccountAuthRequestDto, Account>();
            CreateMap<AccountAuthResponseDto, Account>();
            CreateMap<Account,AccountAuthRequestDto>();
            CreateMap<Account,AccountAuthResponseDto>();

        }
    }
}
