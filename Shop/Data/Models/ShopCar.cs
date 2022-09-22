using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCar
    {
        private readonly AppDBContent appDBContent;

        public ShopCar(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCarID { get; set; }
        public List<ShopCarItem> ListShopItems { get; set; }

        public static ShopCar GetShopCar(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string ShopCarID = session.GetString("CarID") ?? Guid.NewGuid().ToString();

            session.SetString("CarID", ShopCarID);

            return new ShopCar(context) { ShopCarID = ShopCarID };

        }

        public void AddToCar(Car car)
        {
            this.appDBContent.shopCarItem.Add(new ShopCarItem {
                ShopCarID = ShopCarID,
                Car = car,
                Price = car.Price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCarItem> GetShopItems()
        {
            return appDBContent.shopCarItem.Where(c => c.ShopCarID == ShopCarID).Include(s => s.Car).ToList();
        }
    }
}
