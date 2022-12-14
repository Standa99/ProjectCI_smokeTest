using dusicyon_midnight_tribes_backend.Models.APIRequests;
using dusicyon_midnight_tribes_backend.Models.APIResponses;
using dusicyon_midnight_tribes_backend.Models.Entities;
using dusicyon_midnight_tribes_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace dusicyon_midnight_tribes_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerManagementController : ControllerBase
    {
        //private static string _hashedPassword;
        private readonly IPlayerManagementService _playerManagementService;

        public PlayerManagementController(IPlayerManagementService playerManagementService)
        {
            _playerManagementService = playerManagementService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterNewPlayer([FromBody] PlayerRegitstrationRequest request)
        {
            var registrationResult = _playerManagementService.Register(request);

            if (registrationResult)
            {
                return Ok(new {Status = "Ok"});
            }
            return StatusCode(409, new { Error = "Username already taken" });
            
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginPlayer([FromBody] PlayerLoginRequest request)
        {
            string token;
            int result;
            
            _playerManagementService.Login(request, out token, out result);

            switch (result)
            {
                case 0: return StatusCode(404, new PlayerLoginResponse { Status = "Error", Error = "No such player registered." });
                    break;

                case -1: return StatusCode(401, new PlayerLoginResponse { Status = "Error", Error = "Wrong password." });
                    break;

                case 1: return Ok(new PlayerLoginResponse { Status = "Ok", VerificationToken = token });
                    break;

                default: return StatusCode(400, new PlayerLoginResponse { Status = "Error", Error = "Unknown error." });
            }
        }

        // This is just to test authentication via token works.
        [HttpPost("get-player"), Authorize]
        public async Task<ActionResult<Player>> GetPlayer([FromHeader]string authorization)
        {
            string jwt = authorization.Substring(7);
            
            var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);

            int playerId = Int32.Parse(token.Claims.FirstOrDefault(c => c.Type == "nameid").Value);

            return Ok(_playerManagementService.GetPlayer(playerId));
        }
    }
}