using Microsoft.EntityFrameworkCore;
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
            string[] tableNames = new string[] { "Products", "Categories", "Inventory", "Receipts", "Reviews", "Users" };

            TruncateAll(context, tableNames);
            context.Database.EnsureCreated();

            if (context.Products != null && context.Products.Any())
            {
                return;
            }

            //var categories = new Category[] {
            //    new Category{ Name = "Category1", TaxRate = 0.5m, Products = context.Products.Where(p => p.Name == "Product1" && p.Name =="Product2" && p.Name == "Product3").ToList()},
            //    new Category{ Name = "Category2", TaxRate = 1.5m, Products = context.Products.Where(p => p.Name == "Product4" && p.Name =="Product5" && p.Name == "Product6").ToList()},
            //    new Category{ Name = "Category3", TaxRate = 2.5m, Products = context.Products.Where(p => p.Name == "Product7" && p.Name =="Product8" && p.Name == "Product9").ToList()}
            //};

            var categories = new Category[] {
                new Category{ Name = "Category1", TaxRate = 0.5m,},
                new Category{ Name = "Category2", TaxRate = 1.5m,},
                new Category{ Name = "Category3", TaxRate = 2.5m,}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var products = new Product[] {
                new Product {Price = 100, Name = "Product1", Reviews = new Review[] {
                    new Review{ Title = "Johns Review", Description = "Johns Review Description"},
                    new Review{ Title = "Pauls Review", Description = "Pauls Review Description"},
                    new Review{ Title = "Alexas Review", Description = "Alexas Review  Description"}
                },Category = context.Categories.SingleOrDefault(category => category.Name == "Category1")
                },
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



            var inventory = new Inventory //looks like aggregate root
            {
                CurrentAmount = 200,
                Products = context.Products.ToList(),
                Quantity = 20
            };

            context.Inventories.Add(inventory);
            context.SaveChanges();
        }

        private static void TruncateAll(ApplicationDbContext context, string[] tables)
        {
            foreach (var table in tables)
            {
                //var cmdText =  string.Format("DELETE FROM [{0}] DBCC CHECKIDENT ([{0}], RESEED, [0|1])", table);
                var cmdText = string.Format("ALTER TABLE {0} NOCHECK Constraint All DELETE TABLE Products", table);

                context.Database.ExecuteSqlCommand(cmdText);
            }
           
        }
    }
}
