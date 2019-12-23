using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.Models.MusicStore;
using MVCMusicStore2019.ViewModels;
using System.Globalization;
using System.IO;

namespace MVCMusicStore2019.Controllers
{
    public class AdminAlbumController : Controller
    {
        // GET: AdminAlbum
        private readonly IEntityRepository<Album> _Service;
        public AdminAlbumController(IEntityRepository<Album> service)
        {
            _Service = service;
        }
        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollection = new List<AlbumViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                var vm = new AlbumViewModel();
                vm.MapToModel(item);
                vm.OrderNumber = (++count).ToString();
                vmCollection.Add(vm);
            }
            ViewBag.Title = "专辑";
            return View(vmCollection);
        }
        public JsonResult GetGenreList()
        {
            var entityList = _Service.GetRelevance<Genre>().ToList();
            var vmList = new List<GenreViewMdoel>();
            foreach(var item in entityList)
            {
                var boVm = new GenreViewMdoel(item);
                vmList.Add(boVm);
            }
            return Json(vmList);
        }
        public JsonResult GetArtistList()
        {
            var entityList = _Service.GetRelevance<Artist>().ToList();
            var vmList = new List<ArtistViewModel>();
            foreach (var item in entityList)
            {
                var boVm = new ArtistViewModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description
                };
                vmList.Add(boVm);
            }
            return Json(vmList);
        }
        public JsonResult GetAlbumTypeList()
        {
            var entityList = _Service.GetRelevance<AlbumType>().ToList();
            var vmList = new List<AlbumTypeViewModel>();
            foreach (var item in entityList)
            { 
                var boVm = new AlbumTypeViewModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description
                };
                vmList.Add(boVm);
            }
            return Json(vmList);
        }
        public ActionResult CreateOrEdit(string id = null)
        {
            bool isNew = false;
            Guid Id;
            var vm = new AlbumViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new AlbumViewModel(entity);
                ViewBag.Operation = "修改";

            }
            else
            {
                ViewBag.Operation = "新建";
                ViewBag.isNew = isNew;
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                Album entity = new Album();
                var minDate = DateTime.Parse("1999-1-1");
                var maxDate = DateTime.Now;
                if (model.IssueDate< minDate || model.IssueDate > maxDate)
                {
                    model.IssueDate = maxDate;
                }
                entity.MapToModel(model);
                if(model.GenreID!=Guid.Empty)
                {

                    entity.Genre = _Service.GetSingleReleVvance<Genre>(model.GenreID);
                    entity.GenreID = model.GenreID;
                   
                }
                if (model.AlbumTypeID!=Guid.Empty)
                {

                    entity.AlbumType = _Service.GetSingleReleVvance<AlbumType>(model.AlbumTypeID);
                    entity.AlbumTypeID = model.AlbumTypeID;
                }
                if (model.ArtistID!=Guid.Empty)
                {

                    entity.Artist = _Service.GetSingleReleVvance<Artist>(model.ArtistID);
                    entity.ArtistID = model.ArtistID;
                }
                if(model.IssueDate==null)
                {
                    entity.IssueDate = DateTime.Now;
                }
                if (model.ID != Guid.Empty)
                {
                    _Service.Edit(entity);
                    ViewBag.Messages = "修改成功";
                }
                else
                {
                    entity.ID = Guid.NewGuid();
                    _Service.AddAndSave(entity);
                    ViewBag.Messages = "新增成功";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(Guid id)
        {
            if (id != null)
            {
                if (_Service.Delete(id))
                {
                    ViewBag.Message = "删除成功";
                }
                else
                {
                    ViewBag.Message = "删除失败";
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "请正确选择需要删除的记录";
            }
            return View();
        }

        public JsonResult UploadImgFile(HttpPostedFileBase imgFile)
        {
            if (imgFile.ContentLength == 0)
            {
                return Json(new
                {
                    upStatus = false,
                    upMessage = "请选择图片上传"
                }, "text/html");
            }
            //生成图片文件名
            var timStampStrimg = DateTime.Now.ToString("yyyy-mm-dd-hh-mm-dd-ffff", DateTimeFormatInfo.InvariantInfo);
            var result = "Album_" + timStampStrimg;
            int startIndex = imgFile.FileName.IndexOf(".");
            var suffix = imgFile.FileName.Substring(startIndex, imgFile.FileName.Length - startIndex);
            var fileName = Path.Combine(Request.MapPath("~/PICS"), Path.GetFileName(result + suffix));
            try
            {
                imgFile.SaveAs(fileName);
                return Json(new
                {
                    imgUrlString = result + suffix,
                    upStatus = true,
                    upMessage = "图片上传成功！"
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    upStatus = true,
                    upMessage = "图片上传失败！"

                }, "json/html");
            }
        }
    }
}