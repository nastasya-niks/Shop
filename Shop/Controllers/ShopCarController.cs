using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCarController: Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCar _shopCar;

        public ShopCarController(IAllCars carRep, ShopCar shopCar)
        {
            _carRep = carRep;
            _shopCar = shopCar;
        }

        public ViewResult Index()
        {
            var items = _shopCar.GetShopItems();
            _shopCar.ListShopItems = items;

            var obj = new ShopCarViewModel
            {
                ShopCar = _shopCar
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCar(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _shopCar.AddToCar(item);
            }

            return RedirectToAction("Index");
        }
    }
}
