using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestIt.Models
{
    public class Aanvraag
    {
        //properties van de aanvraag
        public int Id { get; set; }
        [Required(ErrorMessage ="Gelieve een titel mee te geven aan de aanvraag")]
        public string Titel { get; set; }
        [Required(ErrorMessage ="Gelieve een korte omschrijving mee te geven aan de aanvraag")]
        public string Omschrijving { get; set; }

        
        [Display(Name = "Start Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDatum { get; set; }

        [Display(Name = "Eind Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EindDatum { get; set; }
        [Display(Name = "Link klant")]
        public string LinkVoorbeeldKlant { get; set; }
        [Display(Name = "Link behandelaar")]
        public string LinkVoorbeeldBehandelaar { get; set; }


        public bool? IsVraag { get; set; }

        //relatie met berichten
        public ICollection<Bericht> Berichten { get; set; }


        //relatie met users
        public string BehandelaarId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        //relatie met behandelaar

             
       


        // relatie met status
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

    }
}
