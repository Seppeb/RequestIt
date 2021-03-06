﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefoon nummer")]
        public string PhoneNumber { get; set; }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public string StatusMessage { get; set; }
    }
}
