using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {            
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            using (var context = new CarDealerContext())
            {
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();

            //    ImportSuppliers(context, suppliersXml);
            //    ImportParts(context, partsXml);
            //    ImportCars(context, carsXml);
            //    ImportCustomers(context, customersXml);
            //    ImportSales(context, salesXml);

                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //var sales = context.Sales
            //    .Select(s => new ExportSaleDto
            //    {
            //        Car = new ExportCarBySaleDto
            //        {
            //            Make = s.Car.Make,
            //            Model = s.Car.Model,
            //            TravelledDistance = s.Car.TravelledDistance
            //        },

            //        Discount = $"{s.Discount:f0}",
            //        CustomerName = s.Customer.Name,
            //        Price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
            //        PriceWithDiscount = 
            //            $"{s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100m)):0.####}"
            //    })
            //    .ToArray();

            var sales = context.Sales
                .ProjectTo<ExportSaleDto>(Mapper.Configuration)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    XmlQualifiedName.Empty
                });

            serializer.Serialize(new StringWriter(sb), sales, namespaces);
            
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .ProjectTo<ExportCustomerDto>(Mapper.Configuration)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportCarWithPartsDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(Mapper.Configuration)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportSupplierDto[]), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportBmwDto>(Mapper.Configuration)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportBmwDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(Mapper.Configuration)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    new XmlQualifiedName("","")
                });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer =
                new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            var salesDtos =
                (ImportSaleDto[])serializer.Deserialize(new StringReader(inputXml));

            var sales = new HashSet<Sale>();

            var customersIds = context.Customers
                .Select(c => c.Id)
                .ToArray();

            var carsIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            foreach (var saleDto in salesDtos)
            {
                if (carsIds.Contains(saleDto.CarId))
                {
                    sales.Add(Mapper.Map<Sale>(saleDto));
                }
                
            }

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = 
                new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customersDtos = 
                (ImportCustomerDto[]) serializer.Deserialize(new StringReader(inputXml));

            var customers = new HashSet<Customer>();

            foreach (var customerDto in customersDtos)
            {
                customers
                    .Add(Mapper.Map<Customer>(customerDto));
            }

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsParsed = XDocument.Parse(inputXml)
               .Root
               .Elements()
               .ToArray();

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            var existingPartsIds = context.Parts
                .Select(p => p.Id)
                .ToArray();

            foreach (var parsedCar in carsParsed)
            {
                var car = new Car
                {
                    Make = parsedCar.Element("make").Value,
                    Model = parsedCar.Element("model").Value,
                    TravelledDistance = long.Parse(parsedCar.Element("TraveledDistance").Value),
                };

                cars.Add(car);

                var carPartsIds = parsedCar
                    .Element("parts")
                    .Elements()
                    .Select(e => int.Parse(e.Attribute("id").Value))
                    .Distinct()
                    .ToArray();

                foreach (var partId in carPartsIds)
                {
                    if (existingPartsIds.Contains(partId))
                    {
                        partsCars.Add(new PartCar
                        {
                            PartId = partId,
                            Car = car
                        });
                    }
                }
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partsCars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";           
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer =
                new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partsDto =
                (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));

            HashSet<Part> parts = new HashSet<Part>();

            var suppliersIds = context.Suppliers
                .Select(s => s.Id)
                .ToHashSet();

            foreach (var partDto in partsDto)
            {
                var part = Mapper.Map<Part>(partDto);

                if (suppliersIds.Contains(part.SupplierId))
                {
                    parts.Add(part);
                }
                
            }

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = 
                new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto =
                (ImportSupplierDto[]) serializer.Deserialize(new StringReader(inputXml));

            HashSet<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}