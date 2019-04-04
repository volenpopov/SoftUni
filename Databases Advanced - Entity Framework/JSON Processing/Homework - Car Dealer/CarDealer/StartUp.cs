using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        private const string IMPORT_MSG = "Successfully imported {0}.";

        public static IMapper mapper =
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            })
            .CreateMapper();

        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                Console.WriteLine(GetCarsWithTheirListOfParts(context));
            }
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //var sales = context.Sales                
            //    .Select(s => new
            //    {
            //        car = new
            //        {
            //            s.Car.Make,
            //            s.Car.Model,
            //            s.Car.TravelledDistance
            //        },

            //        customerName = s.Customer.Name,
            //        Discount = $"{s.Discount:f2}",
            //        price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
            //        priceWithDiscount = 
            //            $"{s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount/100)):f2}"                        
            //    })
            //    .Take(10)
            //    .ToArray();

            var sales = context.Sales
                .Take(10)
                .ProjectTo<SalesDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //var customers = context.Customers
            //    .Where(c => c.Sales.Count > 0)
            //    .Select(c => new
            //    {
            //        fullName = c.Name,
            //        boughtCars = c.Sales.Count,
            //        spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
            //    })
            //    .OrderByDescending(c => c.spentMoney)
            //    .ToArray();

            var customers = context.Customers
                .ProjectTo<TotalSalesByCustomerDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            return JsonConvert.SerializeObject(customers,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },

                    Formatting = Formatting.Indented
                });
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //var carsWithParts = context.Cars
            //    .Select(c => new
            //    {
            //        car = new
            //        {
            //            c.Make,
            //            c.Model,
            //            c.TravelledDistance
            //        },

            //        parts = c.PartCars
            //            .Select(pc => new
            //            {
            //                pc.Part.Name,
            //                Price = pc.Part.Price.ToString("f2")
            //            })
            //            .ToArray()
            //    })
            //    .ToArray

            var carsWithParts = context.Cars
                .ProjectTo<CarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

           return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);            
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<SupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .ProjectTo<ToyotaCarDto>(mapper.ConfigurationProvider)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            //var customersJson = context.Customers
            //    .ProjectTo<OrderedCustomerDto>(mapper.ConfigurationProvider)
            //    .ToArray();

            //Array.Sort(customersJson);

            var customersJson = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<OrderedCustomerDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(customersJson, Formatting.Indented);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            //int salesCount = 0;

            //foreach (var sale in sales)
            //{
            //    if (context.Cars.Select(c => c.Id).Contains(sale.CarId)
            //        && context.Customers.Select(c => c.Id).Contains(sale.CustomerId)
            //        && !context.Sales.Contains(sale))
            //    {
            //        context.Sales.Add(sale);
            //        salesCount++;
            //    }
            //}

            context.SaveChanges();

            return string.Format(IMPORT_MSG, sales.Length);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, customers.Length);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);

            foreach (var car in cars)
            {
                if (!context.Cars.Contains(car))
                {
                    context.Cars.Add(car);
                }
                
                int[] carPartsIds = car.PartsIds
                    .Distinct()
                    .ToArray();

                foreach (var partId in carPartsIds)
                {
                    var partCar = new PartCar();
                    partCar.PartId = partId;
                    partCar.CarId = car.Id;

                    if (!context.PartCars.Contains(partCar) 
                        && context.Parts.Select(p => p.Id).Contains(partId))
                    {
                        context.PartCars.Add(partCar);
                    }                    
                }
            }

            context.SaveChanges();

            return string.Format(IMPORT_MSG, cars.Length);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            parts = parts
                .Where(p => context.Suppliers
                        .Select(s => s.Id)
                        .Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, parts.Length);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return string.Format(IMPORT_MSG, suppliers.Length);
        }
    }
}

//TO RESET AND POPULATE DB:

//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();

//string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
//Console.WriteLine(ImportSuppliers(context, suppliersJson));

//string partsJson = File.ReadAllText("../../../Datasets/parts.json");
//Console.WriteLine(ImportParts(context, partsJson));

//string carsJson = File.ReadAllText("../../../Datasets/cars.json");
//Console.WriteLine(ImportCars(context, carsJson));

//string customerJson = File.ReadAllText("../../../Datasets/customers.json");
//Console.WriteLine(ImportCustomers(context, customerJson));

//string salesJson = File.ReadAllText("../../../Datasets/sales.json");
//Console.WriteLine(ImportSales(context, salesJson));