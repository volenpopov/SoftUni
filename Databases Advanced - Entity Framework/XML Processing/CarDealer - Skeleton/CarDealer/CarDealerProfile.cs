using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Car, ExportCarDto>();

            this.CreateMap<Car, ExportBmwDto>();

            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(dto => dto.PartsCount, src => src.MapFrom(s => s.Parts.Count));

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dto => dto.BoughtCars, src => src.MapFrom(c => c.Sales.Count))
                .ForMember(dto => dto.SpentMoney,
                           src => src.MapFrom(c => c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));

            this.CreateMap<Sale, ExportSaleDto>()
                .ForMember(dto => dto.Car, src => src.MapFrom(s => s.Car))
                .ForMember(dto => dto.Discount, src => src.MapFrom(s => $"{s.Discount:f0}"))
                .ForMember(dto => dto.CustomerName, src => src.MapFrom(s => s.Customer.Name))
                .ForMember(dto => dto.Price, src => src.MapFrom(s => $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}"))
                .ForMember(dto => dto.PriceWithDiscount,
                           src => src.MapFrom(s => 
                                $"{(s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100M))):0.####}"));
        }
    }
}
