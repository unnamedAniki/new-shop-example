using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.DAL.Connect
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder арр)
        {
            var scope = арр.ApplicationServices.CreateScope();
            ProductContext context = scope.ServiceProvider.GetRequiredService<ProductContext>();
            if (!context.Category.Any())
            {
                context.Category.AddRange(
                    new Category { Name = "Shirt" },
                    new Category { Name = "Coat" },
                    new Category { Name = "Pants" }
                    );
            }
            if (!context.Color.Any())
            {
                context.Color.AddRange(
                    new Color { Name = "Black" },
                    new Color { Name = "Red" },
                    new Color { Name = "White" }
                    );
            }
            context.SaveChanges();
            if (!context.Product.Any())
            {
                context.Product.AddRange(
                    new Product { Name = "Футболка", Notes = "Черная минималистичная футболочка", Price=12.10m, CategoryID=1, ColorID=1 },
                    new Product { Name = "Плащ против дождика", Notes = "Минималистичный плащ от дождика", Price = 22.30m, CategoryID = 2 },
                    new Product { Name = "Штаны против мороза", Notes = "Минималистичные штаны от мороза", Price = 15.55m, CategoryID = 3 },
                    new Product { Name = "Штаны против ветра", Notes = "Минималистичные штаны от ветра", Price = 15.55m, CategoryID = 3 },
                    new Product { Name = "Штаны против засухи", Notes = "Минималистичные штаны от засухи", Price = 15.55m, CategoryID = 3 },
                    new Product { Name = "Плащ против ветра", Notes = "Минималистичный плащ от ветра", Price = 15.55m, CategoryID = 2 }, 
                    new Product { Name = "Плащ против засухи", Notes = "Минималистичный плащ от засухи", Price = 22.30m, CategoryID = 2 },
                    new Product { Name = "Футболка", Notes = "Белая минималистичная футболочка", Price = 12.10m, CategoryID = 1, ColorID = 3 },
                    new Product { Name = "Футболка", Notes = "Красная минималистичная футболочка", Price = 12.10m, CategoryID = 1, ColorID = 2 }
                    );
            }
            context.SaveChanges();
        }
    }
}
