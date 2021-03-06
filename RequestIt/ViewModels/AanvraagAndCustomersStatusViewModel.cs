﻿using RequestIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestIt.ViewModels
{
    public class AanvraagAndCustomersStatusViewModel
    {
        public ApplicationUser Users { get; set; }
        public IEnumerable<Aanvraag> Aanvragen { get; set; }
        public Status Status { get; set; }     
    }
}
