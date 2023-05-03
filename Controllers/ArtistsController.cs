using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F2022A6DS.Models;

namespace F2022A6DS.Controllers
{
    public class ArtistsController : Controller
    {
        // Manger
        Manager m = new Manager();

        // GET: Artists
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            var artists = m.ArtistGetAll();
            return View(artists);
        }

        // GET: Artists/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var artists = m.ArtistGetById(id.GetValueOrDefault());

            // Checking if tracks is null
            if (artists == null)
            {
                return HttpNotFound();
            }
            // else
            return View(artists);
        }

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            // Create a form of new Artist Add Form View Model
            var form = new ArtistAddFormViewModel();

            // SelectList for Genre List
            var selectedGenre = m.GenreGetAll().First().Id;
            form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name", selectedGenre);

            return View(form);
        }

        // POST: Artists/Create
        [Authorize(Roles = "Executive")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newArtistItem)
        {
            try
            {
                // Validate the input
                if (!ModelState.IsValid)
                {
                    return View(newArtistItem);
                }

                var addArtistItem = m.ArtistAdd(newArtistItem);

                if (addArtistItem == null)
                {
                    return View(newArtistItem);
                }
                // else
                return RedirectToAction("details", new { id = addArtistItem.Id });
            }
            catch
            {
                return View();
            }
        }
        
        // GET: artist/{id}/addalbum
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artists = m.ArtistGetById(id.GetValueOrDefault());

            if (artists != null)
            {
                // Create a form of new Album Add Form View Model
                var form = new AlbumAddFormViewModel();

                // Passing Artist Name
                form.ArtistName = artists.Name;

                // SelectList for Genre List
                var selectedGenre = m.GenreGetAll().First().Id;
                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name", selectedGenre);

                return View(form);
            }
            // else
            return HttpNotFound();
        }

        // POST: artist/{id}/addalbum
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel newAlbumItem)
        {
            try
            {
                // Validate the input
                if (!ModelState.IsValid)
                {
                    return View(newAlbumItem);
                }

                var addAlbumItem = m.AlbumAdd(newAlbumItem);

                if (addAlbumItem == null)
                {
                    return View(newAlbumItem);
                }
                // else
                return RedirectToAction("details", "Albums", new { id = addAlbumItem.Id });
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            // Get the artist by id
            var artists = m.ArtistGetById(id.GetValueOrDefault());

            if (artists != null)
            {
                // Make a new form
                var form = new ArtistMediaItemAddFormViewModel();

                // Add artist info to the form
                form.ArtistId = artists.Id;
                form.ArtistName = artists.Name;

                return View(form);
            }
            // else
            return HttpNotFound();
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addmediaitem")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMediaItem(ArtistMediaItemAddViewModel newArtistMediaItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newArtistMediaItem);
                }

                var artistMediaItem = m.ArtistMediaItemAdd(newArtistMediaItem);

                if (artistMediaItem != null)
                {
                    return RedirectToAction("details", "artists", new { id = artistMediaItem.Id });
                }
                // else
                return View(newArtistMediaItem);

            }
            catch
            {
                return View();
            }

        }
    }
}
