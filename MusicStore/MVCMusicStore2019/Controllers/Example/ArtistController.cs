using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers.Example
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            List<ArtistViewModel> aTVM = new List<ArtistViewModel>();
            return View(aTVM);
        }
    }
}