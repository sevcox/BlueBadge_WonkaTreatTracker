﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.CandyModels
{
    public class CandyListItem
    {
        public int CandyId { get; set; }
        public string TreatName { get; set; }
        public TypeOfCandy CandyType { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }

    }
}