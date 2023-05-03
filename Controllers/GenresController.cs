using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2022A6DS.Controllers
{
    public class GenresController : Controller
    {
        // Manager
        Manager m = new Manager();

        // GET: Genres
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            return View(m.GenreGetAll());
        }
    }
}
