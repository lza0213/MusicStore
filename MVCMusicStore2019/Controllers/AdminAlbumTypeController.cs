using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.Models.MusicStore;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers
{
    public class AdminAlbumTypeController : Controller
    {
        // GET: AdminAlbumType
        private readonly IEntityRepository<AlbumType> _Service;
        public AdminAlbumTypeController(IEntityRepository<AlbumType> service)
        {
            _Service = service;
        }
        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollection = new List<AlbumTypeDisplayViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                var vm = new AlbumTypeDisplayViewModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description
                };
                vm.OrderNumber = (++count).ToString();
                vmCollection.Add(vm);
            }
            ViewBag.Title = "流派";
            return View(vmCollection);
        }
        public ActionResult CreateOrEdit(string id = null)
        {
            bool isNew = false;
            Guid Id;
            var vm = new AlbumTypeViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new AlbumTypeViewModel(entity);
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
        public ActionResult CreateOrEdit(AlbumTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                AlbumType entity = new AlbumType
                {
                    ID = model.ID,
                    Name = model.Name,
                    Description = model.Description
                };

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
    }
}
