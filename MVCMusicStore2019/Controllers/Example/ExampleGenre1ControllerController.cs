using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers.Example
{
    public class ExampleGenre1ControllerController : Controller
    {
        // GET: ExampleGenre1Controller
        public ActionResult Index()
        {
            List<GenreViewMdoel> gVMD = new List<GenreViewMdoel>();
            return View(gVMD);
        }
    }
}