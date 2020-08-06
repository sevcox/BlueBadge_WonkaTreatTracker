﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.GoldenTicketModels
{
    public class GoldenTicketDetail
    {
        public int TicketId { get; set; }
        public int CandyId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? CreatedUtc { get; set; }
        public string CandyName { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }

    }
}
