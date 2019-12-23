using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers.Example
{
    public class ExmapleArtistController : Controller
    {
        // GET: ExmapleArtist
        public ActionResult Index()
        {
            List<ArtistViewModel> aVM = new List<ArtistViewModel>();

            return View(aVM);
        }
    }
}