using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TripsLogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TripsLogApp.Controllers
{
    public class HomeController : Controller
    {
        private TripDetailContext context { get; set; }

        public HomeController(TripDetailContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            TempData.Clear();

            var trip = context.TripDetails
                .OrderBy(s => s.StartDate)
                .ToList();
            return View(trip);
        }
    }
}
