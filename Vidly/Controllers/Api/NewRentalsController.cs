using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/newrentals/
        public IHttpActionResult GetRentals(Rental rental)
        {
            var activeRentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(a => a.DateReturned == null)
                .ToList();

            return Ok(activeRentals);
        }

        //POST /api/newrentals/
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/newrentals/1
        [HttpDelete]
        public void DeleteRental(int id, Movie movie)
        {
            var rentalInDb = _context.Rentals
                .Include(r => r.Movie)
                .SingleOrDefault(r => r.Id == id);

            var movieRented = _context.Movies.Single(
                m => m.Id == rentalInDb.Movie.Id);

            if (movieRented.Id == rentalInDb.Movie.Id)
                    movieRented.NumberAvailable++;
                    rentalInDb.DateReturned = DateTime.Now;

            if (rentalInDb == null)
                NotFound();
            
            _context.SaveChanges();
        }
    }
}
