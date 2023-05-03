using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;

namespace F2022A6DS.Controllers
{
    public class ArtistMediaItemsController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        // GET: mediaitem
        public ActionResult Index()
        {
            return View("index", "home");
        }

        // GET: mediaitem/5
        [Authorize(Roles = "Coordinator")]
        [Route("mediaitem/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            // Attempt to get the matching object
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Return a file content result
                // Set the Content-Type header, and return the photo bytes
                return File(o.Content, o.ContentType);
            }
        }

        // GET: mediaitem/5/Download
        [Authorize(Roles = "Coordinator")]
        [Route("mediaitem/{stringId}/download")]
        public ActionResult DetailsDownload(string stringId = "")
        {
            // Attempt to get the matching object
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Get file extension, assumes the web server is Microsoft IIS based
                // Must get the extension from the Registry (which is a key-value storage structure for configuration settings, for the Windows operating system and apps that opt to use the Registry)

                // Working variables
                string extension;
                RegistryKey key;
                object value;

                // Open the Registry, attempt to locate the key
                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + o.ContentType, false);
                // Attempt to read the value of the key
                value = (key == null) ? null : key.GetValue("Extension", null);
                // Build/create the file extension string
                extension = (value == null) ? string.Empty : value.ToString();

                // Create a new Content-Disposition header
                var cd = new System.Net.Mime.ContentDisposition
                {
                    // Assemble the file name + extension
                    FileName = $"mediaitem-{stringId}{extension}",
                    // Force the media item to be saved (not viewed)
                    Inline = false
                };
                // Add the header to the response
                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(o.Content, o.ContentType);
            }
        }
    }
}
