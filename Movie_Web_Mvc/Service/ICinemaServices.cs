using Movie_Web_Mvc.Models;
using System.Collections.Generic;

namespace Movie_Web_Mvc.Service
{
    public interface ICinemaServices
    {
        Task<IEnumerable<Cinema>> GetAll();
        Cinema GetById(int id);
        void Add(Cinema cinema);
        void Update(int id, Cinema cinema);
        void Delete(int id);
    }
}
