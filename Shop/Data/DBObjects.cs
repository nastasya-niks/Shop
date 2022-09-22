using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                     new Car
                     {
                         Name = "Tesla",
                         ShortDesc = "Быстрый автомобиль",
                         longDesc = "Красивый, быстрый и очень тихий автомобиль",
                         Img = "/img/Tesla.jpg",
                         Price = 45000,
                         IsFavorite = true,
                         Available = true,
                         Category = Categories["Электромобили"]
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
                        Category = Categories["Классические автомобили"]
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
                        Category = Categories["Классические автомобили"]
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
                        Category = Categories["Электромобили"]

                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan.jpg",
                        Price = 14000,
                        IsFavorite = false,
                        Available = true,
                        Category = Categories["Электромобили"]
                    }
                    );
            }
            content.SaveChanges();
        }
            

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get {           
                if (category == null){

                    var list = new Category[]
                    {
                        new Category { CategoryName = "Электромобили", Desc = "Современный вид транспорта" },
                        new Category { CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        category.Add(el.CategoryName, el);
                    }
                }
                return category;
            }
        }
    }
}
