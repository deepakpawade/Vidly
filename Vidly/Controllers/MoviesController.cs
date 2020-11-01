using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);




            // ViewData["Movie"] = movie; //passing data to views thr. dictionary


            //different types of results
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new
            //{
            //    page = 1, sortBy = "name"  //anonymous object
            //});
        }

        public ActionResult Edit(int id)  //this will appear on movies/edit/1 where 1 is the id parameter
        {
            return Content("id=" + id);
        }


        public ActionResult Index(int? pageIndex, string sortBy)  //'?' makes the parameter nullable so it can run
                                                                  //a default value when no parameter is passed
                                                                  //without giving an exception. String is nullable
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";
            return Content(String.Format("pageIndex = {0}&sortBy = {1}", pageIndex, sortBy));
        }  // works like this : https://localhost:44356/movies?pageIndex=2&sortBy=shrek


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]  //attribute routes
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}