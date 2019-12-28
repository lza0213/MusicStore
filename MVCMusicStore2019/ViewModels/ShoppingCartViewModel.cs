using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> Items { get; set; }
        public string Id { get; set; } //购物车id
        public string UserId { get; set; } //当前登录用户ID

        [Display(Name ="数量")]
        public int TotaQuantity { get; }

        [Display(Name = "金额")]
        public decimal TotalPrice { get; }
        public ShoppingCartViewModel(ShoppingCart model)
        {
            if (Items != null)
            {
                this.Items = model.Items;
            }
            this.Id = model.ID;
            this.UserId = model.UserID;
            this.TotaQuantity = model.TotalQuantity;
            this.TotalPrice = model.TotaPrice;
        }
    }
}