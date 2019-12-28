using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStore
{
    public class OrderItem
    {
        public Guid ID { get; set; }
        public Guid AlbumID { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public OrderItem()
        {
            this.ID = Guid.NewGuid();
            this.Quantity = 0;
        }
        public OrderItem(OrderItem item)
        {
            this.ID = Guid.NewGuid();
            this.AlbumID = item.AlbumID;
            this.Quantity = 0;
            if(this.Order!=null)
            {
                this.ID = item.Order.ID;
                this.Order.UserName = item.Order.UserName;
                this.Order.OrderTime = item.Order.OrderTime;
            }
        }
    }
    
    public class Order
    {
        public Guid ID { get; set; }//订单编号
        public string UserName { get; set; }//
        public DateTime OrderTime { get; set; }//订单生成时间
        public virtual ICollection <OrderItem> OrderItems { get; set; }
        
        public Order()
        {
            this.ID = Guid.NewGuid();
            
            this.OrderTime = DateTime.Now;
        }
        public Order(Order order)
        {
            this.ID = Guid.NewGuid();
            this.UserName = order.UserName;
            this.OrderTime = DateTime.Now;

        }
    }
}