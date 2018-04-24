using RequestIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class UsersAanvraagStatusViewModel
    {
        public IEnumerable<Aanvraag> Aanvragen { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public Status Status { get; set; }

    }
}
