using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Repository
{
    /// <summary>
    /// 购物车公共组件实现
    /// </summary>
    public class ShoppingCartService:IShoppingCartService
    {
        public MusicDbContext _context { get; private set; }
        public ShoppingCartService(MusicDbContext context)
        {
            this._context = context;
        }
        public ShoppingCart GetCart()
        {
            var userName = HttpContext.Current.User.Identity.Name;//取当前用户的用户名
            var userId = _context.Users.SingleOrDefault(x => x.UserName == userName).Id;//根据用户名获取用户ID
             
            return null;
        }
    }
}