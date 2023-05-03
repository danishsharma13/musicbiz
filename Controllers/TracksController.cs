using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F2022A6DS.Models;

namespace F2022A6DS.Controllers
{
    public class TracksController : Controller
    {
        // Manager
        Manager m = new Manager();

        // GET: Tracks
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            var tracks = m.TrackGetAll();
            return View(tracks);
        }

        // GET: Tracks/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var tracks = m.TrackGetById(id.GetValueOrDefault());

            // Checking if tracks is null
            if (tracks == null)
            {
                return HttpNotFound();
            }
            // else
            return View(tracks);
        }

        // GET: clip/5
        [Route("clip/{id}")]
        public ActionResult TrackAudio(int? id)
        {
            // Attempt to get the matching object
            var o = m.TrackAudioGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Set the Content-Type header, and return the audio bytes
                // If there was no audio for a track then it would throw an
                // exception here
                if (o.AudioContentType != null)
                {
                    return File(o.Audio, o.AudioContentType);
                }
                // else
                return HttpNotFound();
            }
        }

        // GET: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var tracks = m.TrackGetById(id.GetValueOrDefault());

            // Checking if tracks is not null
            if (tracks != null)
            {
                var form = m.mapper.Map<TrackWithDetailsViewModel, TrackEditFormViewModel>(tracks);

                return View(form);

            }
            // else
            return HttpNotFound();
        }

        // POST: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditViewModel newTrackItem)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Edit", new { id = newTrackItem.Id });
                }
                else if (id.GetValueOrDefault() != newTrackItem.Id)
                {
                    return RedirectToAction("Index");
                }

                // In Post, we need to send the new Playlist data to the database
                // and once valiated we save it to the database
                var editTrackItem = m.TrackEdit(newTrackItem);

                if (editTrackItem == null)
                {
                    return RedirectToAction("Edit", new { id = newTrackItem.Id });
                }
                else
                {
                    return RedirectToAction("Details", new { id = newTrackItem.Id });
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            // Find the track to delete
            var tracks = m.TrackGetById(id.GetValueOrDefault());

            // If tracks aint null
            if (tracks != null)
            {
                return View(tracks);
            }
            return RedirectToAction("Index");
        }

        // POST: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if(m.TrackDelete(id.GetValueOrDefault()))
                {
                    return RedirectToAction("Index");
                }
                // else
                return RedirectToAction("Delete", new { id = id });

            }
            catch
            {
                return View();
            }
        }
    }
}
