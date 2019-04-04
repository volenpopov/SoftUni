using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;
using System.Globalization;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, OrderedCustomerDto>()
                .ForMember(oc => oc.BirthDate, 
                            c => c.MapFrom(cu => cu
                                            .BirthDate
                                            .ToString("dd/MM/yyyy", 
                                             CultureInfo.InvariantCulture)));

            this.CreateMap<Car, ToyotaCarDto>();

            this.CreateMap<Supplier, SupplierDto>()
                .ForMember(dto => dto.PartsCount, 
                           src => src.MapFrom(s => s.Parts.Count));

            this.CreateMap<Customer, TotalSalesByCustomerDto>()
                .ForMember(dto => dto.FullName, src => src.MapFrom(c => c.Name))
                .ForMember(dto => dto.BoughtCars, src => src.MapFrom(c => c.Sales.Count))
                .ForMember(dto => dto.SpentMoney, 
                    src => src.MapFrom(c => c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));

            this.CreateMap<Car, CarDto>();

            this.CreateMap<Sale, SalesDto>()
                .ForMember(dto => dto.Car, src => src.MapFrom(s => s.Car))
                .ForMember(dto => dto.CustomerName, src => src.MapFrom(s => s.Customer.Name))
                .ForMember(dto => dto.Discount, src => src.MapFrom(s => s.Discount.ToString("f2")))
                .ForMember(dto => dto.Price, src => src.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2")))
                .ForMember(dto => dto.PriceWithDiscount,
                    src => src.MapFrom(s => 
                        (s.Car.PartCars.Sum(pc => pc.Part.Price) 
                        * (1 - (s.Customer.IsYoungDriver ? s.Discount / 100 : (s.Discount + 5) / 100)))
                        .ToString("f2")));

            this.CreateMap<Part, PartDto>()
                .ForMember(dto => dto.Price, src => src.MapFrom(p => p.Price.ToString("f2")));

            this.CreateMap<Car, CarWithPartsDto>()
                .ForMember(dto => dto.Car, src => src.MapFrom(c => c))
                .ForMember(dto => dto.Parts, src => src.MapFrom(c => c.PartCars.Select(pc => pc.Part)));
            
        }
    }
}
