using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StartechMovies.Models;
using StartechMovies.Helpers;

namespace StartechMovies.Controllers
{
    //DEMO-ROUTAGE
    [RoutePrefix("films")] 
    public class MoviesController : Controller
    {
        private static IMovieRepository repository;

        // GET: Movies
        //DEMO-ROUTAGE
        [Route("")] 
        public ActionResult Index()
        {
            InitMovies();
            return View(repository.Get());
        }

        // GET: Movies/Details/5
        //DEMO-ROUTAGE
        [Route("{id}")]
        public ActionResult Details(int id)
        {
            InitMovies();
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieModel;
            repository.TryGet(id, out movieModel);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            InitMovies();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imdbID,Title,Year,Rated,Released,Runtime,Genre,Director,Writer,Actors,Plot,Language,Country,Awards,Poster,Metascore,imdbRating,imdbVotes,Type")] Movie movieModel)
        {
            InitMovies();
            if (ModelState.IsValid)
            {
                
                repository.Add(movieModel);
                return RedirectToAction("Index");
            }

            return View(movieModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            InitMovies();
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieModel;
            repository.TryGet(id, out movieModel);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,imdbID,Title,Year,Rated,Released,Runtime,Genre,Director,Writer,Actors,Plot,Language,Country,Awards,Poster,Metascore,imdbRating,imdbVotes,Type")] Movie movieModel)
        {
            InitMovies();
            if (ModelState.IsValid)
            {
                repository.Update(movieModel);

                return RedirectToAction("Index");
            }
            return View(movieModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            InitMovies();
            if (id <=0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieModel;
            repository.TryGet(id, out movieModel);
            bool result = repository.Delete(id);
            if (!result)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InitMovies();
            bool result = repository.Delete(id);
            return RedirectToAction("Index");
        }

        private void InitMovies()
        {
            if (repository == null)
            {
                repository = MoviesHelper.InitMovies();
            }
        }

    }
}
