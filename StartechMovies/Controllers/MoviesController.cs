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
        // GET: Movies
        //DEMO-ROUTAGE
        [Route("")] 
        public ActionResult Index()
        {
            InitMovies();
            return View(movies);
        }

        // GET: Movies/Details/5
        //DEMO-ROUTAGE
        [Route("{id}")]
        public ActionResult Details(string id)
        {
            InitMovies();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieModel = movies.Find(m => m.imdbID.Equals(id));
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
                movies.Add(movieModel);
                return RedirectToAction("Index");
            }

            return View(movieModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(string id)
        {
            InitMovies();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieModel = movies.Find(m => m.imdbID.Equals(id));
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
        public ActionResult Edit([Bind(Include = "imdbID,Title,Year,Rated,Released,Runtime,Genre,Director,Writer,Actors,Plot,Language,Country,Awards,Poster,Metascore,imdbRating,imdbVotes,Type")] Movie movieModel)
        {
            InitMovies();
            if (ModelState.IsValid)
            {
                Movie movieToDelete = movies.Find(m => m.imdbID.Equals(movieModel.imdbID));
                int index = movies.IndexOf(movieToDelete);
                movies.Remove(movieToDelete);
                movies.Insert(index, movieModel);
                return RedirectToAction("Index");
            }
            return View(movieModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(string id)
        {
            InitMovies();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieModel = movies.Find(m => m.imdbID.Equals(id));
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InitMovies();
            Movie movieModel = movies.Find(m => m.imdbID.Equals(id));
            movies.Remove(movieModel);
            return RedirectToAction("Index");
        }


        private static List<Movie> movies = null;

        private void InitMovies()
        {
            if (movies == null)
            {
                movies = MoviesHelper.InitMovies();
            }
        }

    }
}
