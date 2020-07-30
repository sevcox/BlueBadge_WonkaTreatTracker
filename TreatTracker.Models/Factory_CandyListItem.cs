﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models
{
    public class Factory_CandyListItem
    {
        public int CandyId { get; set; }
        [Display(Name = "Name")]
        public string TreatName { get; set; }
        public int FactoryId { get; set; }
        [Display(Name = "Name")]
        public string LocationName { get; set; }
        public int Quantity { get; set; }
    }
}
