using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Web_Mvc.Models;
using Movie_Web_Mvc.Service;
using Movie_Web_Mvc.ViewModel;
using System.Reflection.Metadata.Ecma335;

namespace Movie_Web_Mvc.Controllers
{

    public class MoviesController : Controller
    {
        private readonly IMovieServices _service;

        public MoviesController(IMovieServices service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            var allMovies = _service.GetAll();
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }



        public IActionResult Details(int id)
        {
            var MovieDetail = _service.GetById(id);
            return View(MovieDetail);
        }


        public IActionResult Create()
        {
            var cinemas = _service.GetCinemas();


            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");


            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                var cinemas = _service.GetCinemas();

                ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");

                _service.AddNewMovie(Movie);
                return RedirectToAction(nameof(Index));

            }
            return View(Movie);


        }
        //public IActionResult Edit(int id)
        //{
        //    var movieDetails = _service.GetById(id);
        //    if (movieDetails == null)
        //    {
        //        return View("NotFound");
        //    }

        //    var response = new MovieViewModel()
        //    {
        //        Id = movieDetails.Id,
        //        Name = movieDetails.Name,
        //        Description = movieDetails.Description,
        //        Price = movieDetails.Price,
        //        StartDate = movieDetails.StartDate,
        //        EndDate = movieDetails.EndDate,
        //        Logo = movieDetails.Logo,
        //        MovieCategory = movieDetails.MovieCategory,
        //        CinemaId = movieDetails.CinemaId,
        //    };

        //    var cinemas = _service.GetCinemas();
        //    ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");

        //    return View(response);
        //}
        //[HttpPost]
        //public IActionResult Edit(int id, MovieViewModel movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return View("NotFound");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        var cinemas = _service.GetCinemas();
        //        ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
        //        return View(movie);
        //    }
        //    _service.UpdateMovie(movie);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
