using Microsoft.AspNetCore.Mvc;
using Movie_Web_Mvc.Models;
using Movie_Web_Mvc.Service;
using System.Collections.Generic;


namespace Movie_Web_Mvc.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaServices _service;

        public CinemasController(ICinemaServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAll();
            return View(allCinemas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
               

                _service.Add(cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);


        }


        public IActionResult Details(int id)
        {
            var cinemaDetails = _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        public IActionResult Edit(int id)
        {
            var cinemaDetails = _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        //[HttpPost]
        //public IActionResult Edit(Cinema cinemaDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _service.Update(cinemaDetails);
        //        return RedirectToAction("Index");
        //    }
        //    return View(cinemaDetails);
        //}
        [HttpPost]
        public IActionResult Edit(int id,Cinema cinemaDetails)
        {
           
                _service.Update(id,cinemaDetails);
                return RedirectToAction("Index");
           
            //return View(cinemaDetails);
        }




        public IActionResult Delete(int id)
        {
            var cinemaDetails = _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var cinemaDetails = _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


