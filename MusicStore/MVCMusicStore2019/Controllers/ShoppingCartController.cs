using MVCMusicStore2019.Models.MusicStore;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly IEntityRepository<Album> _Service;
        public ShoppingCartController(IShoppingCartService cartService,
            IEntityRepository<Album> service)
        {
            this._cartService = cartService;
            this._Service = service;
        }
        public ActionResult AddToCart(Guid id,decimal price,string name)
        {
            var cart = _cartService.GetCart();//获取购物车内容
            var album = _Service.GetAll().Single(x => x.ID == id);//获取专辑信息
            if (album != null)
            {
                _cartService.AddToCart(album.ID, price, album.Name);
            }
            else
            {
                ViewBag.Msg = "查无此专辑，请不要非法操作！";

            }

            return RedirectToAction("Index");
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = _cartService.GetCart();//获取购物车内容
            ShoppingCartViewModel vm = new ShoppingCartViewModel(cart)
            {

            };
            return View();
        }
    }
}