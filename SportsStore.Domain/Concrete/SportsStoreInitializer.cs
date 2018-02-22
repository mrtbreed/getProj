using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class SportsStoreInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        List<Product> products = new List<Product>();
        public SportsStoreInitializer()
        {
            products.Add(new Product() { Name = "Kayak", Description = "A boat for one persone", Category = "Watersport", Price = 275 });
            products.Add(new Product() { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersport", Price = 48.95M });
            products.Add(new Product() { Name = "Soccer Ball", Description = "FIFA-Approved Size and weight", Category = "Soccer", Price = 19.50M });
            products.Add(new Product() { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 34.95M });
            products.Add(new Product() { Name = "Stadium", Description = "Flat-packed, 35,000-seat stadium", Category = "Soccer", Price = 79500m });
            products.Add(new Product() { Name = "Thinking Cap", Description = "Improve your brain efficiency by 75%", Category = "Chess", Price = 16.00m });
            products.Add(new Product() { Name = "Unsteady Chair", Description = "Secretly give your opponent disadvantage", Category = "Chess", Price = 29.95m });
            products.Add(new Product() { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75.00M });
            products.Add(new Product() { Name = "Bling-Bling", Description = "Gold-plated, diamond-studded King", Category = "Chess", Price = 1200.00M });
        }
        protected override void Seed(EFDbContext context)
        {

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
