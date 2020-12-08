using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronicCars.Core.Models;
namespace ElectronicCars.Core
{
    public interface ISaleRepository
    {
        Task<Sale> GetSale(int id, bool includeRelated = true);
        void Add(Sale sale);
        void Remove(Sale sale);
        Task<ICollection<SalesQueryResult>> GetSales(SaleQuery filter);
    }
}