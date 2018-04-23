using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RequestIt.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Geef een naam aan de status")]
        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        //Relatie met aanvraag

        [Required]
        public ICollection<Aanvraag> Aanvragen { get; set; }
        

    }
}
