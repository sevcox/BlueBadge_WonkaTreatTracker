﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.GoldenTicketModels
{
    public class GoldenTicketListItem
    {
        public int Ticketid { get; set; }
        public int CandyId { get; set; }
        public string CandyName { get; set; }
        
    }
}
