using Microsoft.AspNetCore.Identity;
using RequestIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class ApplicationUserIndexManagementViewModel
    {

        public string UserId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }

        public string RoleName { get; set; }
    }
}
