using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrders allorders;
        private readonly ShopCar shopCar;

        public OrderController(IAllOrders allorders, ShopCar shopCar)
        {
            this.allorders = allorders;
            this.shopCar = shopCar;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCar.ListShopItems = shopCar.GetShopItems();
            if (shopCar.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "В корзине пусто");
            }
            if (ModelState.IsValid)
            {
                allorders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
