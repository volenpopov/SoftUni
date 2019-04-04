using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private const string IMPORT_MSG = "Successfully imported {0}";
        private static string usersXml = File.ReadAllText("../../../Datasets/users.xml");
        private static string productsXml = File.ReadAllText("../../../Datasets/products.xml");
        private static string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
        private static string categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //ImportUsers(context, usersXml);
                //ImportProducts(context, productsXml);
                //ImportCategories(context, categoriesXml);
                //ImportCategoryProducts(context, categoriesProductsXml);

                Console.WriteLine(GetUsersWithProducts(context));
            }
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new ExportUsersWithProductsDto
            {
                Count = context.Users.Count(usr => usr.ProductsSold.Any()),
                Users = context.Users.Where(usr => usr.ProductsSold.Any())
                    .Select(u => new ExportUserDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,                        
                        SoldProducts = new SoldProductsDto
                        {
                            Count = u.ProductsSold.Count,
                            SoldProducts = u.ProductsSold.Select(sp => new ExportProductDto
                            {
                                Name = sp.Name,
                                Price = sp.Price
                            })
                            .OrderByDescending(sp => sp.Price)
                            .ToArray()
                        }                        
                    })
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };
            
            var serializer =
               new XmlSerializer(typeof(ExportUsersWithProductsDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), users, namespaces);
            
            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AvgPrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                    TotalRevenue = c.CategoryProducts.Select(cp => cp.Product.Price).Sum()
                })
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);
            
            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportSoldProductsByUser
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ExportProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportSoldProductsByUser[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Include(p => p.Buyer)
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductsInRangeDto>(Mapper.Configuration)               
                .ToArray();

            var serializer = 
                new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = 
                new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = 
                (ImportCategoryProductDto[]) serializer.Deserialize(new StringReader(inputXml));

            var categoriesIds = context.Categories
                .Select(c => c.Id)
                .ToArray();

            var productsIds = context.Products
                .Select(p => p.Id)
                .ToArray();

            HashSet<CategoryProduct> categoriesProducts = new HashSet<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                if (categoriesIds.Contains(categoryProductDto.CategoryId)
                    && productsIds.Contains(categoryProductDto.ProductId))
                {
                    categoriesProducts
                        .Add(Mapper.Map<CategoryProduct>(categoryProductDto));
                }
            }

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, categoriesProducts.Count);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = 
                new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto =
                (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var categories = new HashSet<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, categories.Count);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = 
                new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = 
                (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));

            HashSet<Product> products = new HashSet<Product>();
            //HashSet<int> userIds = context.Users.Select(u => u.Id).ToHashSet();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);

                //if (userIds.Contains(productDto.SellerId))
                //{
                    products.Add(product);
                //}                
            }

            context.Products.AddRange(products);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, products.Count);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        { 
            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            HashSet<User> users = new HashSet<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, users.Count);
        }
    }
}