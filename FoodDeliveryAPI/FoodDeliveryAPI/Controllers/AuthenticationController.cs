using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;
using FoodDeliveryAPI.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FoodDeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private ILogger<AuthenticationController> _logger; 

        public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("customer")]
        
        public ActionResult AuthenticateCustomer([FromBody] UserCredentials userCredentials)
        {
            if(userCredentials == null)
            {
                return Unauthorized("Invalid credentials");
            }

            try
            {
                var user = _authenticationService.AuthenticateCustomer(userCredentials);
                return Ok(_authenticationService.GenerateToken(user));

            }catch(CustomerNotFoundException ex)
            {
                _logger.LogError("{@ex}", ex);
                return Unauthorized(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError("{@ex}", ex);
                return Unauthorized(ex.Message);
            }

        }

        [HttpPost("deliveryperson")]
        public ActionResult AuthenticateDeliveryPerson([FromBody] UserCredentials userCredentials)
        {
            if(userCredentials == null)
            {
                return Unauthorized("Invalid credentials");
            }

            try
            {
                var user = _authenticationService.AuthenticateDeliveryPerson(userCredentials);
                return Ok(_authenticationService.GenerateToken(user));

            }
            catch (NoDeliveyPersonFoundException ex)
            {
                _logger.LogError("{@ex}", ex);
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@ex}", ex);
                return Unauthorized(ex.Message);
            }

        }
        [HttpPost("admin")]
        public ActionResult<Token> AuthenticateAdmin(UserCredentials userCredentials)
        {
            try
            {
                var user = _authenticationService.AuthenticateAdmin(userCredentials);
                return Ok(_authenticationService.GenerateToken(user));

            }
            catch (NoDeliveyPersonFoundException ex)
            {
                _logger.LogError("{@ex}", ex);
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("{@ex}", ex);
                return Unauthorized(ex.Message);
            }
        }
    }
}
