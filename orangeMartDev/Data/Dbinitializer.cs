using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orangeMartDev.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products != null && context.Products.Any())
            {
                return;
            }
            var products = new Product[] {
                new Product{Price = 100, Name = "Product1" },
                new Product{Price = 200, Name = "Product2" },
                new Product{Price = 300, Name = "Product3" },
                new Product{Price = 400, Name = "Product4" },
                new Product{Price = 500, Name = "Product5" },
                new Product{Price = 600, Name = "Product6" },
                new Product{Price = 700, Name = "Product7" },
                new Product{Price = 800, Name = "Product8" },
                new Product{Price = 900, Name = "Product9" },

            };
            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            var categories = new Category[] {
                new Category{ Name = "Category1", TaxRate = 0.5m, Products = context.Products.Where(p => p.Name == "Product1" && p.Name =="Product2" && p.Name == "Product3").ToList()},
                new Category{ Name = "Category2", TaxRate = 1.5m, Products = context.Products.Where(p => p.Name == "Product4" && p.Name =="Product5" && p.Name == "Product6").ToList()},
                new Category{ Name = "Category3", TaxRate = 2.5m, Products = context.Products.Where(p => p.Name == "Product7" && p.Name =="Product8" && p.Name == "Product9").ToList()}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var inventory = new Inventory //looks like aggregate root
            {
                CurrentAmount = 200,
                Products = context.Products.ToList(),
                Quantity = 20
            };

            context.Inventories.Add(inventory);
            context.SaveChanges();
        }
    }
}
