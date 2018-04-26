using RequestIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class Statuslijstaanvraag
    {
        public IEnumerable<Status> Statusessen { get; set; }
        public Aanvraag Aanvraag { get; set; }
        
    }
}
