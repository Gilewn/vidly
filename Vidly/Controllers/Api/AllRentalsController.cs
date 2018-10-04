using System.Linq;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class AllRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public AllRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/allrentals/
        public IHttpActionResult GetAllRentals(Rental rental)
        {
            var allRentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToList();

            return Ok(allRentals);
        }
    }
}
