using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsController: Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategories;

        public CarsController(IAllCars iallCars, ICarsCategory iCarsCat)
        {
            _allCars = iallCars;
            _carsCategories = iCarsCat;
        }
        [Route ("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else{
                if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили"));
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Классические автомобили"));
                    currCategory = "Классические автомобили";
                }
            }
       
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                CarCategory = currCategory

            };

            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }
    }
}
