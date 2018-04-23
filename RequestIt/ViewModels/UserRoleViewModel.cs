using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class UserRoleViewModel
    {

        //user
        public string UserName { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }

        //rol
        public string RoleName { get; set; } 


    }
}
