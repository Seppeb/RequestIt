using RequestIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class AanvraagAndCustomerViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Aanvraag> Aanvragen { get; set; }
    }
}
