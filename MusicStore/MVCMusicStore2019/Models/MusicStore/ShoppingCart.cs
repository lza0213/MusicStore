using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStore
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }//购物车中的条目
        public string ID { get; set; }//购物车
        public string UserID { get; set; }//当前用户ID
        public int TotalQuantity  //专辑总数量
        {
            get { return this.Items.Sum(x => x.Quantity); }
        }
        public decimal TotaPrice   //总金额
        {
            get { return this.Items.Sum(x => x.Price * x.Quantity); }
        }
        public ShoppingCart()
        {
            this.ID = "ShoppingCart_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff", DateTimeFormatInfo.InvariantInfo);
            Items = new List<ShoppingCartItem>();
        }
    }

    [Serializable]//将ShoppingCartItem进行序列化
    public class ShoppingCartItem
    {
        public Guid ID { get; set; }//以AlbumID作为Items的id
        public string AlbumName { get; set; }
        public decimal Price { get; set; }//价格
        public int Quantity { get; set; }//数量
        public decimal SuTotaPrice   //单行物品计价
        {
            get { return this.Price * this.Quantity; }
        }
    }

    
    
}