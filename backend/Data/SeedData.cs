using Backend.Models;
using System;
using System.Collections.Generic;

namespace Backend.Data
{
    public static class SeedData
    {
        public static void Initialize(DataContext context)
        {
            // Şirket verileri ekle
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company { Name = "Acme Corp", Address = "123 Main St", PhoneNumber = "555-1234", Email = "info@acme.com" },
                    new Company { Name = "Beta Inc", Address = "456 Elm St", PhoneNumber = "555-5678", Email = "info@beta.com" }
                );
            }

            // Stok verileri ekle
            if (!context.Stocks.Any())
            {
                context.Stocks.AddRange(
                    new Stock { Name = "Elma", Description = "Yeşil Elma", Quantity = 100, UnitPrice = 3.50M },
                    new Stock { Name = "Armut", Description = "Sarı Armut", Quantity = 50, UnitPrice = 4.00M }
                );
            }

            // Müşteri verileri ekle
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { Name = "Ahmet Yılmaz", Address = "789 Oak St", PhoneNumber = "555-7890", Email = "ahmet@yilmaz.com" },
                    new Customer { Name = "Fatma Kaya", Address = "321 Pine St", PhoneNumber = "555-6543", Email = "fatma@kaya.com" }
                );
            }

            // Veritabanına kaydet
            context.SaveChanges();
        }
    }
}
