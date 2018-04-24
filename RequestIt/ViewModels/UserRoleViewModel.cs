using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class UserRoleViewModel
    {

        //user
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }
        
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        [Display(Name = "Telefoon")]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        //rol

        [Display(Name = "Rol")]
        public string RoleName { get; set; } 


    }
}
