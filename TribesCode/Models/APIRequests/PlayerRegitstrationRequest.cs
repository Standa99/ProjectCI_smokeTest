using System.ComponentModel.DataAnnotations;

namespace dusicyon_midnight_tribes_backend.Models.APIRequests
{
    public class PlayerRegitstrationRequest
    {
        [Required(ErrorMessage = "Username is required."),
            MinLength(4, ErrorMessage = "Username must be at least 4 characters long.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required."),
            EmailAddress (ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required, MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string PasswordAgain { get; set; }
    }
}