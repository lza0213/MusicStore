using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Repository
{
    /// <summary>
    /// 购物车组件
    /// </summary>
    interface IShoppingCartService
    {
        ShoppingCart GetCart();//获取当前用户的购物车
    }
}
