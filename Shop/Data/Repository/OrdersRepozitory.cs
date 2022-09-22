using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepozitory : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCar shopCar;

        public OrdersRepozitory(AppDBContent appDBContent, ShopCar shopCar)
        {
            this.appDBContent = appDBContent;
            this.shopCar = shopCar;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCar.ListShopItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price,
                    
                };
                
                appDBContent.OrderDetail.Add(orderDetail);
                
            }
            
            appDBContent.SaveChanges();
        }
    }
}
