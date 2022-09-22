using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars { 
            get {
                return new List<Car>
                {
                    new Car {
                        Name = "Tesla", 
                        ShortDesc = "Быстрый автомобиль", 
                        longDesc = "Красивый, быстрый и очень тихий автомобиль", 
                        Img = "/img/Tesla.jpg", 
                        Price = 45000, 
                        IsFavorite = true, 
                        Available = true, 
                        Category = _categoryCars.AllCategories.First()
                    }, 
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/ford.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и стильный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/bmw.jpg",
                        Price = 65000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mersedess S class",
                        ShortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/mers.jpg",
                        Price = 14000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()

                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan.jpg",
                        Price = 14000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
                }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
