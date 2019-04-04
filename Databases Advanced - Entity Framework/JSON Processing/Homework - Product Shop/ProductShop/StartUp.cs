using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {
                Console.WriteLine(GetUsersWithProducts(context));
            }
                        
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Count(p => p.Buyer != null),
                        Products = x.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(z => new
                            {
                                z.Name,
                                z.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray();

            return JsonConvert.SerializeObject(
                new
                {
                    UsersCount = users.Length,
                    Users = users
                },
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },

                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x    => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = (x.CategoryProducts.Sum(cp => cp.Product.Price)
                                   / x.CategoryProducts.Count).ToString("f2"),
                    totalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(categories,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy(),
                    },

                    Formatting = Formatting.Indented
                }
            );

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName
                    })
                    .ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Include(p => p.Seller)
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = 
                JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
          
            foreach (var categoryProduct in categoriesProducts.Distinct())
            {
                context.CategoryProducts.Add(categoryProduct);
            }

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Distinct().ToArray().Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            int categoriesCount = 0;

            foreach (var category in categories)
            {
                if (EntityValidator.IsValid(category))
                {
                    context.Categories.Add(category);
                    categoriesCount++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {categoriesCount}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            int productCount = 0;

            foreach (var product in products)
            {
                if (EntityValidator.IsValid(product))
                {
                    context.Products.Add(product);
                    productCount++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {productCount}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            int usersCount = 0;

            foreach (var user in users)
            {
                if (EntityValidator.IsValid(user))
                {
                    context.Add(user);
                    usersCount++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {usersCount}";
        }
    }
}