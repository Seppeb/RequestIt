using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestIt.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Geef een naam aan de status")]
        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        //Relatie met aanvraag

        public int AanvraagId { get; set; }
        [ForeignKey("AanvraagId")]
        public virtual Aanvraag aanvraag { get; set; }
        

    }
}
