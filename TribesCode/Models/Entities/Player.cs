namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? VerificationTokenExpiresAt { get; set; }
        public string? ForgottenPasswordToken { get; set; }
        public DateTime? ForgottenPasswordTokenExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //this is commented out, so I can start working with database with no other tables but Users
        //public List<Kingdom> Kingdoms { get; set; }
    }
}