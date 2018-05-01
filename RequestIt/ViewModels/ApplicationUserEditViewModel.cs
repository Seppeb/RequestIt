using RequestIt.Models;
using System.ComponentModel.DataAnnotations;

namespace RequestIt.ViewModels
{
    public class ApplicationUserEditViewModel
    {

        public ApplicationUser Userbyid { get; set; }

        public string Rol { get; set; }

        [Display(Name = "Maak Administrator")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Maak Behandelaar")]
        public bool IsBehandelaar { get; set; }

    }
}
