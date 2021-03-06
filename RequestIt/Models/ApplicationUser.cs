﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RequestIt.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {        

        public string Voornaam { get; set; }        
        public string Achternaam { get; set; }

        public ICollection<Aanvraag> Aanvragen { get; set; }       

    }
}
