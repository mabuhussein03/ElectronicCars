
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronicCars.Core.Models;
namespace ElectronicCars.Core
{
    public interface ILocationRepository
    {
        Task<SalesLocation> GetSaleLocation(int id, bool includeRelated = true);
        void Add(SalesLocation saleLocation);
        void Remove(SalesLocation saleLocation);
        Task<QueryResult<SalesLocation>> GetSalesLocation();
    }
}