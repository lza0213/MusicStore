using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.Example
{

    // GET: ExmapleJavaScriptResult
    public class ShoppingCart : List<ShoppingCartItem> { }
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class ExampleJavaScriptResultController : Controller
    {
        private static Dictionary<Guid, int> stock = new Dictionary<Guid, int>();//stock:库存字典
        private static Guid stockA = Guid.NewGuid(), stockB = new Guid(), stockC = Guid.NewGuid();//对库存商品Id进行Guid编号的生成工作
                                                                                                  // GET: ExampleJavaScriptResult

        static ExampleJavaScriptResultController()
        {
            stock.Add(stockA, 10);
            stock.Add(stockB, 20);
            stock.Add(stockC, 30);
        }
        /// <summary>
        /// 库存检查
        /// </summary>

        private bool CheckStock(Guid id, int quantity)
        {
            return stock[id] >= quantity;
        }
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Add(new ShoppingCartItem { Id = stockA, Quantity = 1, Name = "Adidas" });
            cart.Add(new ShoppingCartItem { Id = stockB, Quantity = 1, Name = "AF1" });
            cart.Add(new ShoppingCartItem { Id = stockC, Quantity = 1, Name = "AJ1" });
            return View(cart);
        }
        public ActionResult ProcessOrder(ShoppingCart cart)
        {
            StringBuilder sbd = new StringBuilder();//定义可变字符串
                                                    //库存检查并返回字符串结果
            foreach (var cartItem in cart)
            {
                //判断CheckStock方法是否为ture，为ture不做判断，CheckStock为false时，把值(名称、id)传入可变字符串
                if (!CheckStock(cartItem.Id, cartItem.Quantity))
                {
                    sbd.Append(string.Format("{0}:{1}", cartItem.Name, stock[cartItem.Id]));
                }

            }
            if (string.IsNullOrEmpty(sbd.ToString()))
            {
                return Content("alert('您的订单已成功处理！')", "text/javascript");
            }
            string scriptString = string.Format("alert('库存不足！<{0}')", sbd.ToString().TrimEnd(';'));
            return JavaScript(scriptString);
        }

    }
}