namespace dusicyon_midnight_tribes_backend.Services;

using BCrypt.Net;
using dusicyon_midnight_tribes_backend.Contexts;
using dusicyon_midnight_tribes_backend.Models.APIRequests;
using dusicyon_midnight_tribes_backend.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class PlayerManagementService : IPlayerManagementService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public PlayerManagementService(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public string HashPassword(string password)
    {
        return BCrypt.EnhancedHashPassword(password, hashType: HashType.SHA384);
    }

    public bool VerifyPassword(string password, string passwordHashed)
    {
        return BCrypt.EnhancedVerify(password, passwordHashed, hashType: HashType.SHA384);
    }

    public bool Register(PlayerRegitstrationRequest request)
    {
        var pswHashed = HashPassword(request.Password);

        if (_context.Players.Any(p => p.UserName == request.UserName))
        {
            return false;
        }

        var newPlayer = new Player()
        {
            UserName = request.UserName,
            Email = request.Email,
            PasswordHashed = pswHashed
        };

        _context.Players
            .Add(newPlayer);

        _context.SaveChanges();

        return true;
    }

    public void Login(PlayerLoginRequest request, out string token, out int result)
    {
        var player = _context.Players
            .FirstOrDefault(p => p.UserName == request.UserName);

        token = "";

        if (player != null)
        {
            if (VerifyPassword(request.Password, player.PasswordHashed))
            {
                result = 1;
                token = GenerateToken(player);
            }
            else
            {
                result = -1;
            }
        }
        else
        {
            result = 0;
        }
    }

    public string GenerateToken (Player player)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, player.Id.ToString())
        };

        var expiration = DateTime.Now.AddHours(12);

        var jwt = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: signature);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public Player GetPlayer (int playerId)
    {
        return _context.Players
            .FirstOrDefault(p => p.Id == playerId);
    }
}