using dusicyon_midnight_tribes_backend.Models.APIRequests;
using dusicyon_midnight_tribes_backend.Models.Entities;

namespace dusicyon_midnight_tribes_backend.Services
{
    public interface IPlayerManagementService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHashed);
        bool Register(PlayerRegitstrationRequest request);
        void Login(PlayerLoginRequest request, out string token, out int result);
        Player GetPlayer(int playerId);
    }
}