using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using RequestIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class Statuslijstaanvraag
    {


        public int StatusId { get; set; }
        public SelectList Statusessen { get; set; }

        public string BehandelaarId { get; set; }
      
        public Aanvraag Aanvraag { get; set; }


        
    }
}
