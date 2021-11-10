using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Test.Models
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {
            
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cars.Any())
            {
                context.AddRange(
                    new Car
                    {
                        name = "Tesla Model S",
                        shortDescription = "Быстрый автомобиль",
                        longDescription = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        image = "/img/TeslaModelS.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобиль"]
                    },

                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDescription = "Тихий и спокойный",
                        longDescription = "Удобный для городской жизни",
                        image = "/img/FordFiesta.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Классический автомобиль"]
                    },

                    new Car
                    {
                        name = "BMW M3",
                        shortDescription = "Дерзкий и стильный",
                        longDescription = "Удобный для городской жизни",
                        image = "/img/BMWM3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Классический автомобиль"]
                    },

                    new Car
                    {
                        name = "Mercedes C class",
                        shortDescription = "Уютный и большой",
                        longDescription = "Удобный для городской жизни",
                        image = "/img/MercedesCclass.jpg",
                        price = 40000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Электромобиль"]
                    },

                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDescription = "Бесшумный и экономичный",
                        longDescription = "Удобный для городской жизни",
                        image = "/img/NissanLeaf.jpg",
                        price = 14000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Классический автомобиль"]
                    },

                    new Car
                    {
                        name = "YAZ Buhanka",
                        shortDescription = "Буханистая",
                        longDescription = "Можно возить картошку",
                        image = "/img/YAZBuhanka.jpg",
                        price = 9,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Классический автомобиль"]
                    });
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category {categoryName ="Электромобиль", description="Современный вид транспорта"},
                        new Category {categoryName="Классический автомобиль", description="Машина с видом внутреннего сгорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category element in list)
                    {
                        category.Add(element.categoryName, element);
                    }
                }

                return category;
            }
        }
    }
}
