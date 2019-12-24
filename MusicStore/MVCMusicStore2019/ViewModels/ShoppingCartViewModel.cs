using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> Items { get; set; }
        public string Id { get; set; }
        public string UserId { get; set; }
        public int TotaQuantity { get; }
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