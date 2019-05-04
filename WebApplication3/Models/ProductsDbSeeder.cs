using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_api.Models;

namespace WebApplication3.Models
{
    public class ProductsDbSeeder
    {
        public static void Initialize(ProductsDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any flowers.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Name = "telefon",
                    Description = "White, Yellow",
                    Category ="a",
                    Price = 5
                },
                new Product
                {
                    Name = "telefon1",
                    Description = "White, Yellow",
                    Category = "a",
                    Price = 5
                }
            );
            context.SaveChanges();
        }
    }
}

    
