﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.DTOs;
using ToDo.Core.Interfaces;
using ToDo.Core.Options;
using ToDo.Core.Utils;
using ToDo.Data.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ToDo.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ConfigurationOptions _options;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountService(
            IOptions<ConfigurationOptions> options,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper
            )
        {
            _options = options.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.JwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_options.JwtExpireDays));

            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResultDTO> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager
                .PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, false);
            if (!result.Succeeded)
            {
                throw new ApplicationException(DictionaryResources.InvalidLoginAttempt);
            }

            var user = _userManager.Users
                .SingleOrDefault(u => u.UserName == loginDTO.Username);

            var loginResult = new LoginResultDTO
            {
                Token = GenerateJwtToken(user),
                Id = user.Id,
                Username = user.UserName
            };

            return loginResult;
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<ApplicationUser>(registerDTO);

            if (await _userManager.FindByEmailAsync(user.Email) != null ||
                await _userManager.FindByNameAsync(user.UserName) != null)
                throw new ArgumentException(DictionaryResources.AccountExists);

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException(DictionaryResources.InvalidRegistrationAttempt);
            }
        }
    }
}
