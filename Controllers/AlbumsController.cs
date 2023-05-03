using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F2022A6DS.Models;

namespace F2022A6DS.Controllers
{
    public class AlbumsController : Controller
    {
        // Manager
        Manager m = new Manager();

        // GET: Albums
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            var album = m.AlbumGetAll();
            return View(album);
        }

        // GET: Albums/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());

            // Checking if tracks is null
            if (album == null)
            {
                return HttpNotFound();
            }
            // else
            return View(album);
        }

        // GET: album/{id}/addtrack
        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());

            if (album != null)
            {
                // Create a form of new Album Add Form View Model
                var form = new TrackAddFormViewModel();

                // Passing Artist Name and Id
                form.AlbumId = id.GetValueOrDefault();
                form.AlbumName = album.Name;

                // SelectList for Genre List
                var selectedGenre = m.GenreGetAll().First().Id;
                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name", selectedGenre);

                return View(form);
            }
            // else
            return HttpNotFound();
        }

        // POST: album/{id}/addtrack
        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTrack(TrackAddViewModel newTrackItem)
        {
            try
            {
                // Validate the input
                if (!ModelState.IsValid)
                {
                    return View(newTrackItem);
                }

                var addTrackItem = m.TrackAdd(newTrackItem);

                if (addTrackItem == null)
                {
                    return View(newTrackItem);
                }
                // else
                return RedirectToAction("details", "Tracks", new { id = addTrackItem.Id });
            }
            catch
            {
                return View();
            }
        }
    }
}
