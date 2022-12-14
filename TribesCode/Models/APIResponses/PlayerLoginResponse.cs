namespace dusicyon_midnight_tribes_backend.Models.APIResponses
{
    public class PlayerLoginResponse
    {
        public string Status { get; set; }
        public string VerificationToken { get; set; }
        public string Error { get; set; }
    }
}