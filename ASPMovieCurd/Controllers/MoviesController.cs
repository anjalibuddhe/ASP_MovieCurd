using ASPMovieCurd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ASPMovieCurd.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IConfiguration configuration;
        private MovieCurd curd;


        public MoviesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            curd = new MovieCurd(this.configuration);
        }
        // GET: MoviesController
        public ActionResult Index()
        {
            var model = curd.GetAllMovies();
            return View(model);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                int result = curd.AddMovie(movie);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = curd.GetMovieById(id);
            return View(result);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                int result = curd.UpdateBook(movie);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = curd.GetMovieById(id);
            return View(result);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = curd.DeleteMovies(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
