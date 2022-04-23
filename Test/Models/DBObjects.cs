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
                        Name = "Tesla Model S",
                        ShortDescription = "Быстрый автомобиль",
                        LongDescription = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        Image = "/img/TeslaModelS.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Электромобиль"]
                    },

                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescription = "Тихий и спокойный",
                        LongDescription = "Удобный для городской жизни",
                        Image = "/img/FordFiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Классический автомобиль"]
                    },

                    new Car
                    {
                        Name = "BMW M3",
                        ShortDescription = "Дерзкий и стильный",
                        LongDescription = "Удобный для городской жизни",
                        Image = "/img/BMWM3.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классический автомобиль"]
                    },

                    new Car
                    {
                        Name = "Mercedes C class",
                        ShortDescription = "Уютный и большой",
                        LongDescription = "Удобный для городской жизни",
                        Image = "/img/MercedesCclass.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Электромобиль"]
                    },

                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescription = "Бесшумный и экономичный",
                        LongDescription = "Удобный для городской жизни",
                        Image = "/img/NissanLeaf.jpg",
                        Price = 14000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Классический автомобиль"]
                    },

                    new Car
                    {
                        Name = "YAZ Buhanka",
                        ShortDescription = "Буханистая",
                        LongDescription = "Можно возить картошку",
                        Image = "/img/YAZBuhanka.jpg",
                        Price = 9,
                        IsFavourite = true,
                        Available = true,
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
