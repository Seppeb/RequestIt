using System;
using System.ComponentModel.DataAnnotations;

namespace RequestIt.Models
{
    public class Bericht
    {
        public int BerichtId { get; set; }

        [Required(ErrorMessage = "Een bericht heeft een titel nodig")]
        public string Titel { get; set; }
        [Required(ErrorMessage ="Een bericht heeft een inhoud nodig")]
        public string Inhoud { get; set; }

        [Display(Name = "Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Startdate { get; set; }

        //eventueel interne boodschappen
        //public bool IsIntern { get; set; }

        // Relaties
        public int AanvraagId { get; set; }
        public Aanvraag Aanvraag { get; set; }


    }
}
