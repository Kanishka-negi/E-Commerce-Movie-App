using System;
using System.Collections.Generic;
using System.Linq;
using Movie_Web_Mvc.Models;
using Microsoft.EntityFrameworkCore;
using Movie_Web_Mvc.ViewModel;

namespace Movie_Web_Mvc.Service
{
    public class MovieServices : IMovieServices
    {
        private readonly AppDbContext _dbContext;

        public MovieServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //        public void Add(Movie Movie)
        //        {
        //            _dbContext.Movies.Add(Movie);
        //            _dbContext.SaveChanges();
        //        }

        //        public void AddNewMovie(Movie data)
        //        {
        //            var newMovie = new Movie()
        //            {
        //                Name = data.Name,
        //                Description = data.Description,
        //                Price = data.Price,
        //                Logo = data.Logo,
        //                CinemaId = data.CinemaId,
        //                StartDate = data.StartDate,
        //                EndDate = data.EndDate,
        //                MovieCategory = data.MovieCategory
        //            };

        //            _dbContext.Movies.Add(newMovie);
        //            _dbContext.SaveChanges();
        //        }

        //        public Movie Delete(int id)
        //        {
        //            var Movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

        //            if (Movie != null)
        //            {
        //                _dbContext.Movies.Remove(Movie);
        //                _dbContext.SaveChanges();
        //            }

        //            return Movie;
        //        }

        //        public IEnumerable<Movie> GetAll()
        //        {
        //            return _dbContext.Movies.Include(m => m.Cinema).ToList();
        //        }

        //        public Movie GetById(int id)
        //        {
        //            var Movie = _dbContext.Set<Movie>()
        //                .Include(m => m.Cinema)
        //                .FirstOrDefault(m => m.Id == id);

        //            return Movie;
        //        }

        //        public IEnumerable<Cinema> GetCinemas()
        //        {
        //            return _dbContext.Cinemas.ToList();
        //        }

        //        public Movie UpdateMovie(int id, MovieViewModel movieVM)
        //        {
        //            var existingMovie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

        //            if (existingMovie != null)
        //            {
        //                existingMovie.Name = movieVM.Name;
        //                existingMovie.Description = movieVM.Description;
        //                existingMovie.Price = movieVM.Price;
        //                existingMovie.Logo = movieVM.Logo;
        //                existingMovie.StartDate = movieVM.StartDate;
        //                existingMovie.EndDate = movieVM.EndDate;
        //                existingMovie.MovieCategory = movieVM.MovieCategory;
        //                existingMovie.CinemaId = movieVM.CinemaId;

        //                _dbContext.SaveChanges();
        //            }
        //            return existingMovie;
        //        }

        //        public void UpdateMovie(MovieViewModel movie)
        //        {
        //            UpdateMovie(movie.Id, movie);
        //        }
        //    }
        //}



        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.Include(m => m.Cinema).ToList();
        }


        public Movie GetById(int id)
        {
            var Movie = _dbContext.Set<Movie>()
                .Include(m => m.Cinema)
                .FirstOrDefault(m => m.Id == id);

            return Movie;
        }

        public void Add(Movie Movie)
        {
            _dbContext.Movies.Add(Movie);
            _dbContext.SaveChanges();
        }

        public Movie Update(int id, Movie Movie)
        {
            var existingMovie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if (existingMovie != null)
            {
                existingMovie.Name = Movie.Name;
                existingMovie.Description = Movie.Description;
                existingMovie.Price = Movie.Price;
                existingMovie.Logo = Movie.Logo;
                existingMovie.StartDate = Movie.StartDate;
                existingMovie.EndDate = Movie.EndDate;
                existingMovie.MovieCategory = Movie.MovieCategory;
                existingMovie.CinemaId = Movie.CinemaId;

                _dbContext.SaveChanges();
            }

            return existingMovie;
        }

        public Movie Delete(int id)
        {
            var Movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if (Movie != null)
            {
                _dbContext.Movies.Remove(Movie);
                _dbContext.SaveChanges();
            }

            return Movie;
        }

        public List<Cinema> GetCinemas()
        {

            return _dbContext.Cinemas.ToList();
        }

        public void AddNewMovie(Movie data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                Logo = data.Logo,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory
            };

            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();
        }

        public Movie UpdateMovie(int id, Movie Movie)
        {
            throw new NotImplementedException();
        }
    }
}


