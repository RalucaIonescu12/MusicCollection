﻿using AutoMapper;
using MusicCollection.Helpers.Jwt;
using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using MusicCollection.Models.DTOs;
using MusicCollection.Models.Enums;
using MusicCollection.Repositories.AccountRepository;
using NuGet.DependencyResolver;
using BCryptNet = BCrypt.Net.BCrypt;
namespace MusicCollection.Services.AccountService
{
    public class AccountService : IAccountService
    {
        public IAccountRepository _accountRepository;
        public IMapper _mapper;
        public IJwtUtils _jwtUtils;
        public AccountService(IAccountRepository accountRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public AccountAuthResponseDto Authentificate(AccountAuthRequestDto model)
        {
            var account = _accountRepository.FindByEmail(model.Email);
            if (account == null || !BCryptNet.Verify(model.Password, account.PasswordHash))
            {
                return null;
            }

            // jwt generation
            var jwtToken = _jwtUtils.GenerateJwtToken(account);
            return new AccountAuthResponseDto(account, jwtToken);
        }
        public async Task<Account> AddAccount(AccountCreateDto newAccount)
        {
            var newAccountEntity = _mapper.Map<Account>(newAccount);
            await _accountRepository.CreateAsync(newAccountEntity);
            await _accountRepository.SaveAsync();
            return newAccountEntity;
        }

      
        public async Task DeleteAccount(Guid accountId)
        {
            var accountToDelete = await _accountRepository.FindByIdAsync(accountId);
            _accountRepository.Delete(accountToDelete);
            await _accountRepository.SaveAsync();
        }

        public async Task<List<AccountDto>> GetAll()
        {
            var accounts = await _accountRepository.GetAll();
            return _mapper.Map< List<AccountDto>>(accounts);
        }
        public async Task<AccountDto> GetAccountById(Guid accountId)
        {
            var account = await _accountRepository.GetAccountById(accountId);
            return _mapper.Map<AccountDto>(account);
        }
        public async Task<Account> GetAccountEntityById(Guid accountId)
        {
            var account = await _accountRepository.GetAccountById(accountId);
            return account;
        }
        public async Task Create(AccountAuthRequestDto account)
        {
            var newDBAccount = _mapper.Map<Account>(account);
            newDBAccount.PasswordHash = BCryptNet.HashPassword(account.Password);
            newDBAccount.Role = Role.User;

            await _accountRepository.CreateAsync(newDBAccount);
            await _accountRepository.SaveAsync();
        }
        public async Task CreateAdmin(AccountAuthRequestDto account)
        {
            var newDBAccount = _mapper.Map<Account>(account);
            newDBAccount.PasswordHash = BCryptNet.HashPassword(account.Password);
            newDBAccount.Role = Role.Admin;

            await _accountRepository.CreateAsync(newDBAccount);
            await _accountRepository.SaveAsync();
        }
    }
}
