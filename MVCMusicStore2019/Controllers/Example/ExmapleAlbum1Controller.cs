using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers.Example
{
    public class ExmapleAlbum1Controller : Controller
    {
        // GET: ExmapleAlbum1
        public ActionResult Index()
        {
            List<AlbumViewModel> vm = new List<AlbumViewModel>();
            return View(vm);
        }
        
    }
}