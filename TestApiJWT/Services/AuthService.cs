﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestApiJWT.Helpers;
using TestApiJWT.Models;

namespace TestApiJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicatonClass> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTClass _jwt;
        public AuthService(UserManager<ApplicatonClass> userManager , IOptions<JWTClass> options , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = options.Value;
        }
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registerd!" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username is already registerd!" };

            var user = new ApplicatonClass
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.Firstname,
                LastName = model.Lastname
            };
            var Result = await _userManager.CreateAsync(user,model.Password);
            if (! Result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in Result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModel { Message = errors };
            }
            await _userManager.AddToRoleAsync(user, "User");
            var jwtSecurityToken = await CreateJwtToken(user);
            return new AuthModel
            {
                Email = user.Email,
                Expiration = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };
        }
        public async Task<string> AddRoleAsync(RoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
            {
                return "Invalid User ID or Role";
            }
            if (await _userManager.IsInRoleAsync(user,model.Role))
            {
                return "User already assigned to this role";
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went Wrong";
        }
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || await _userManager.CheckPasswordAsync(user,model.Password))
            {
                authModel.Message = "Email or Password is incorrect";
                return authModel;
            }
            var roleList = await _userManager.GetRolesAsync(user);    
            authModel.IsAuthenticated = true;
            
            var jwtSecurityToken = await CreateJwtToken(user);  
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Expiration = jwtSecurityToken.ValidTo;
            authModel.UserName = user.UserName;
            authModel.Email = user.Email;
            authModel.Roles  = roleList.ToList();


            return authModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicatonClass user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);    

            return jwtSecurityToken;
        }
    }
}
