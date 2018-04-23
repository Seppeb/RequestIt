using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RequestIt.Models;

namespace RequestIt.ViewModels
{
    public class GebruikersManagementViewModel
    {
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Telefoon nummer")]
        public string TelefoonNummer { get; set; }

        [Display(Name = "Maak Administrator")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Maak Behandelaar")]
        public bool IsBehandelaar { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }

    }
}
