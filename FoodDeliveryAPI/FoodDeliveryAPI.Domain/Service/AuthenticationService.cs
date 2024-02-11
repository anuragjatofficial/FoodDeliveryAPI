using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodDeliveryAPI.Domain.Service
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
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));

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
