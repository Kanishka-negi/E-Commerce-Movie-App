//using Movie_Web_Mvc.Models;

//namespace Movie_Web_Mvc.Service
//{
//    public interface IMovieServices
//    {
//        IEnumerable<Movie> GetAll();
//        Movie GetById(int id);
//        void Add(Movie Movie);

//        void AddNewMovie(Movie data);

//        Movie Update(int id, Movie Movie);

//        Movie Delete(int id);
//        List<Cinema> GetCinemas();

//    }
//}


using Movie_Web_Mvc.Models;

namespace Movie_Web_Mvc.Service
{
    public interface IMovieServices
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie Movie);

        void AddNewMovie(Movie data);

        Movie UpdateMovie(int id, Movie Movie);

        Movie Delete(int id);
        List<Cinema> GetCinemas();

    }
}
//using Movie_Web_Mvc.Models;
//using Movie_Web_Mvc.ViewModel;

//namespace Movie_Web_Mvc.Service { 
//    public interface IMovieServices
//{

//    IEnumerable<Movie> GetAll();
//    Movie GetById(int id);
//    void Add(Movie movie);
//    void AddNewMovie(Movie data);
//    Movie UpdateMovie(int id, MovieViewModel movieVM);
//    void UpdateMovie(MovieViewModel movie);
//    Movie Delete(int id);
//    IEnumerable<Cinema> GetCinemas();
//}
//}

