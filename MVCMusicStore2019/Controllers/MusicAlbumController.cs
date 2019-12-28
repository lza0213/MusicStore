using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.Models.MusicStore;
using MVCMusicStore2019.ViewModels;

namespace MVCMusicStore2019.Controllers
{
    public class MusicAlbumController : Controller
    {
        // GET: MusicStoreIndex
        private readonly IEntityRepository<Album> _Service;
        private readonly IEntityRepository<PopularHotList> _phlService;
        public MusicAlbumController(IEntityRepository<Album> service, IEntityRepository<PopularHotList> phlService)
        {
            this._Service = service;
            this._phlService = phlService;
        }
       
        public JsonResult GetPics()
        {
            var entityList = _Service.GetAll();//获取Album所有的数据
            var picList = entityList
                .OrderByDescending(x => x.IssueDate)//按出品日期倒序排序
                .Select(y => y.Urlstring)//选择UrlString一列数据
                .Skip(0)//从结果的第0条
                .Take(5)//取5条数据
                .ToList();
            return Json(picList);
        }
        /// <summary>
        /// 获取album表中的ID，Name，Price，URLsting
        /// 根据发行日期倒序排序
        /// </summary>
        /// <returns></returns>

        public JsonResult GetMusicStoreAlbums()
        {
            var entityList = _Service.GetAll().ToList();
            var jsonResult = entityList
                .OrderByDescending(x => x.IssueDate)//发行日期倒序排序
                .Select(result => new//使用集合索引器方式选择目标列
                {
                    result.ID,
                    result.Name,
                    result.Price,
                    result.Urlstring
                })
                .Skip(0).Take(10)//取1~10条数据
                .ToList();
            return Json(jsonResult);
        }
        public ActionResult  Detail(Guid id)
        {
            var entity = _Service.GetAll().Single(x => x.ID == id);
            AlbumViewModel vm = new AlbumViewModel(entity);
            return View(vm);
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
        public JsonResult AddCTR(Guid id)
        {
            var result = false;
            var entity = _phlService.GetSingleById(id);
            if(entity==null)
            {
                PopularHotList bo = new PopularHotList();
                bo.ID = id;
                bo.Album = _phlService.GetSingleReleVvance<Album>(id);
                bo.AlbumID = id;
                bo.CTR += 1;
                _phlService.AddAndSave(bo);
                result = true;
            }
            else
            {
                 entity.CTR += 1;
                _phlService.Edit(entity);
                result = true;
            }
            return Json(result); 
        }
    }
}