using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers.Example
{
    public class ExmapleAlbumTypeController : Controller
    {
        // GET: ExmapleAlbumType
        public ActionResult Index()
        {
            List<AlbumTypeViewModel> aTVM = new List<AlbumTypeViewModel>();
            return View(aTVM);
        }
    }
}