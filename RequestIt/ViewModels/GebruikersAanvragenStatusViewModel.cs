using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RequestIt.Models;

namespace RequestIt.ViewModels
{
    public class GebruikersAanvragenStatusViewModel
    {
        public string UserId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public  ICollection<Aanvraag> Aanvragen { get; set; }
    }
}
