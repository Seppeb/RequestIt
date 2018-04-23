using System.ComponentModel.DataAnnotations;

namespace RequestIt.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig password")]
        [Compare("Password", ErrorMessage = "Het wachtwoord komt niet overeen")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        [Display(Name ="Telefoon nummer")]
        public string TelefoonNummer { get; set; }

        [Display(Name = "Maak Administrator")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Maak Behandelaar")]
        public bool IsBehandelaar { get; set; }

    }
}
