using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Web.Services.Description;

namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult ActiveRentals()
        {
            var rental = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(a => a.DateReturned == null)
                .ToList();

            return View(rental);
        }

        public ActionResult AllRentals()
        {
            var rental = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToList();

            return View(rental);
        }
    }
}