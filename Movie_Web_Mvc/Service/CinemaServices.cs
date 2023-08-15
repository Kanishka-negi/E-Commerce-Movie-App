using Movie_Web_Mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Movie_Web_Mvc.Service
{
    public class CinemaServices : ICinemaServices
    {
        private readonly AppDbContext _context;

        public CinemaServices(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }




        public async Task<IEnumerable<Cinema>> GetAll()
        {
            var result = await _context.Cinemas.ToListAsync();
            return result;
        }

        public void Delete(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                _context.SaveChanges();
            }
        }

     

        public Cinema GetById(int id)
        {
            var result = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public void Update(int id, Cinema cinema)
        {
            var existingCinema = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            if (existingCinema != null)
            {
                existingCinema.Logo = cinema.Logo;
                existingCinema.Name = cinema.Name;
                existingCinema.Description = cinema.Description;
                _context.SaveChanges();
            }
        }

        
    }
}