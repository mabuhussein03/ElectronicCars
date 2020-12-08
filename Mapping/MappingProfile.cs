using AutoMapper;
using System.Linq;
using ElectronicCars.Controllers.Resources;
using ElectronicCars.Core.Models;
namespace ElectronicCars.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Sale, SaleResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<SaleResource, Sale>();
            CreateMap<SalesLocation, SalesLocationResource>();
            CreateMap<SalesLocationResource, SalesLocation>();
            CreateMap<SaleQueryResource, SaleQuery>();

        }
    }
}