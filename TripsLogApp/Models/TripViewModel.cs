using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TripsLogApp.Models
{
    public class TripViewModel
    {
        public TripDetail TripDetail { get; set; }

        public int PageNumber { get; set; }
    }
        
}
