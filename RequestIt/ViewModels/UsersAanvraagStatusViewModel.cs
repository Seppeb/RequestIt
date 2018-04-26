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
        public Aanvraag Aanvraag { get; set; }

        public Status Status { get; set; }        

        public string UserId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string UserName { get; set; }


    }
}
