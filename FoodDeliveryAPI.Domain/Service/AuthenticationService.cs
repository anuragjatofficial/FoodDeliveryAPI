<<<<<<< HEAD:FoodDeliveryAPI.Domain/Service/AuthenticationService.cs
﻿using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
=======
﻿using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.DTO;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Models;
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Service/AuthenticationService.cs
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/Service/AuthenticationService.cs
namespace FoodDeliveryAPI.Domain.Service
=======
namespace FoodDeliveryAPI.Service
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Service/AuthenticationService.cs
{
    public class AuthenticationService : IAuthenticationService
    {
        private IConfiguration _configuration;

        private FoodDeliveryAPIContext _context;

        public AuthenticationService(IConfiguration configuration,FoodDeliveryAPIContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Token GenerateToken(User user)
        {
<<<<<<< HEAD:FoodDeliveryAPI.Domain/Service/AuthenticationService.cs
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
=======
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Service/AuthenticationService.cs

            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.UserEmail),
                new Claim(ClaimTypes.Role,user.Role),
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires:DateTime.Now.AddHours(2),
                signingCredentials:credentials
            );

            return new Token()
            {
                authToken = new JwtSecurityTokenHandler().WriteToken(token),
                IssuedAt = DateTime.Now,
                ExpireAt = DateTime.Now.AddHours(2),
            };
        }
        
        public User AuthenticateCustomer(UserCredentials credentials)
        {
            return _context.Customers.FirstOrDefault(e => e.UserName == credentials.Username && e.Password == credentials.Password) ?? throw new CustomerNotFoundException($"username or password mismatch");
        }

        public User AuthenticateDeliveryPerson(UserCredentials credentials)
        {
            return _context.DeliveryPersons.FirstOrDefault(e => e.UserName == credentials.Username && e.Password == credentials.Password) ?? throw new NoDeliveyPersonFoundException($"username or password mismatch");
        }

        public User AuthenticateAdmin(UserCredentials credentials)
        {
            return _context.Admins.FirstOrDefault(e => e.UserName == credentials.Username && e.Password == credentials.Password) ?? throw new AdminNotFoundException($"username or password mismatch");
        }
    }
}
