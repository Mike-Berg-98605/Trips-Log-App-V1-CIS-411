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
    public class TripController : Controller
    {
        private TripDetailContext context { get; set; }

        public TripController(TripDetailContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Add(string id = "")
        {
            var viewModel = new TripViewModel();

            if (id.ToLower() == "trippage2")
            {
                var accomodations = TempData[nameof(TripDetail.Accomodations)]?.ToString();

                if (string.IsNullOrEmpty(accomodations))
                {
                    viewModel.PageNumber = 3;
                    var tripDestination = TempData.Peek(nameof(TripDetail.Destination)).ToString();
                    viewModel.TripDetail = new TripDetail { Destination = tripDestination };
                    return View("TripPage3", viewModel);
                }
                else
                {
                    viewModel.PageNumber = 2;
                    viewModel.TripDetail = new TripDetail { Accomodations = accomodations };
                    TempData.Keep(nameof(TripDetail.Accomodations));
                    return View("TripPage2", viewModel);
                }
            }
            else if (id.ToLower() == "trippage3")
            {
                viewModel.PageNumber = 3;
                viewModel.TripDetail = new TripDetail { Destination = TempData.Peek(nameof(TripDetail.Destination)).ToString() };
                return View("TripPage3", viewModel);
            }
            else
            {
                viewModel.PageNumber = 1;
                return View("TripPage1", viewModel);
            }
        }

        [HttpPost]
        public IActionResult Add(TripViewModel viewModel)
        {
            if(viewModel.PageNumber == 1)
            {
                if (ModelState.IsValid)
                {
                    TempData[nameof(TripDetail.Destination)] = viewModel.TripDetail.Destination;
                    TempData[nameof(TripDetail.Accomodations)] = viewModel.TripDetail.Accomodations;
                    TempData[nameof(TripDetail.StartDate)] = viewModel.TripDetail.StartDate;
                    TempData[nameof(TripDetail.EndDate)] = viewModel.TripDetail.EndDate;
                    return RedirectToAction("Add", new { id = "TripPage2" });
                }
                else
                {
                    return View("TripPage1", viewModel);
                }
            }
            else if (viewModel.PageNumber == 2)
            {
                TempData[nameof(TripDetail.PhoneNumber)] = viewModel.TripDetail.PhoneNumber;
                TempData[nameof(TripDetail.Email)] = viewModel.TripDetail.Email;
                return RedirectToAction("Add", new { id = "tripPage3" });
            }
            else if (viewModel.PageNumber == 3)
            {
                viewModel.TripDetail.Destination = TempData[nameof(TripDetail.Destination)].ToString();
                viewModel.TripDetail.Accomodations = TempData[nameof(TripDetail.Accomodations)]?.ToString();
                viewModel.TripDetail.StartDate = (DateTime)TempData[nameof(TripDetail.StartDate)];
                viewModel.TripDetail.EndDate = (DateTime)TempData[nameof(TripDetail.EndDate)];
                viewModel.TripDetail.PhoneNumber = TempData[nameof(TripDetail.PhoneNumber)]?.ToString();
                viewModel.TripDetail.Email = TempData[nameof(TripDetail.Email)]?.ToString();

                context.TripDetails.Add(viewModel.TripDetail);
                context.SaveChanges();
                TempData["message"] = $"Trip to {viewModel.TripDetail.Destination} added.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }        
    }
}
