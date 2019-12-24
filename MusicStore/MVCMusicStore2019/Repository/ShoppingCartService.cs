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
        public  string GetUserID()
        {
            var userName = HttpContext.Current.User.Identity.Name;//取当前用户的用户名
            var userId = _context.Users.SingleOrDefault(x => x.UserName == userName).Id;//根据用户名获取用户ID
            return userId;
        }
        /// <summary>
        /// 获取购物车数据（当前用户）
        /// </summary>
        /// <returns></returns>
        public ShoppingCart GetCart()
        {
            var userid = GetUserID();
            //获取购物车
            var cart = _context.ShoppingCarts.SingleOrDefault(x => x.UserID == userid);
            if (cart != null)
            {
                cart.Items = GetItems(cart.ID);
                return cart;
            }
             
            return null;
        }
        /// <summary>
        /// 获取购物车完成跳转
        /// </summary>
        /// <param name="cartID"></param>
        /// <returns></returns>
        public List<ShoppingCartItem> GetItems(string cartID)
        {
            var entityCollection = _context.ShoppingCarts
                .Where(x => x.ID == cartID)
                .Select(y => y.Items)
                .ToList();
            //获取详单的ID值
            var entity = entityCollection.Select(x => x.Select(y => y.ID));
            var vmCollection = new List<ShoppingCartItem >();

            //把entityCollection读到VmCollection
            foreach (var items in entityCollection)
            {
                ShoppingCartItem bo = new ShoppingCartItem();
                foreach(var item in items)
                {
                    bo.ID = item.ID;
                    bo.AlbumName = item.AlbumName;
                    bo.Price = item.Price;
                    bo.Quantity = item.Quantity;
                }
            }
            return vmCollection;
        }
        /// <summary>
        /// 添加购物车实现
        /// </summary>
        /// <param name="id">音乐专辑ID</param>给ShoppingCart.id
        /// <param name="price">价格</param>
        /// <param name="name">专辑名称</param>给给ShoppingCart。AlbumName
        public void AddToCart(Guid id, decimal price, string name)
        {
            if (id != Guid.Empty)
            {
                //查找购物车是否已有该音乐专辑数据
                ShoppingCartItem cartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.ID == id);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    ShoppingCartItem item = new ShoppingCartItem
                    {
                        ID = id,
                        AlbumName = name,
                        Price = price,
                        Quantity = 1
                    };
                    //查找当前购物车数据
                    var userID = GetUserID();
                    var cart = _context.ShoppingCarts.SingleOrDefault(x => x.UserID == userID);

                    if (cart != null)//用户已有购物车数据，但是很购物车没有当前专辑数据
                    {
                        cart.Items.Add(item);
                        _context.ShoppingCartItems.Add(item);
                    }
                    else
                    {
                        ShoppingCart shoppingCart = new ShoppingCart();
                        shoppingCart.UserID = userID;
                        shoppingCart.Items.Add(item);
                        _context.ShoppingCarts.Add(shoppingCart);
                        _context.ShoppingCartItems.Add(item);
                        _context.SaveChanges();
                    }
                }
            }
            
        }

    }

}