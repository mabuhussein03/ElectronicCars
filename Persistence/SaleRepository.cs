using ElectronicCars.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ElectronicCars.Core.Models;
using ElectronicCars.Extensions;
namespace ElectronicCars.Persistence
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ElectronicCarsDbContext context;

        public SaleRepository(ElectronicCarsDbContext context)
        {
            this.context = context;
        }

        public async Task<Sale> GetSale(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Sales.FindAsync(id);

            return await context.Sales
              .Include(v => v.SalesLocation)
              .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Sale sale)
        {
            context.Sales.Add(sale);
        }

        public void Remove(Sale sale)
        {
            context.Remove(sale);
        }

        public async Task<ICollection<SalesQueryResult>> GetSales(SaleQuery queryObj)
        {
            var result = new List<SalesQueryResult>();

            var query = context.Sales
              .Include(v => v.SalesLocation)
              .AsQueryable();

            // query = query.ApplyFiltering(queryObj);
            foreach (var location in queryObj.Locations)
            {
                var locationFilterdSalse = await query.Where(v => location == v.SalesLocation).ToListAsync();
                var saleMonths = new List<SaleQueryMonths>();
                foreach (var month in queryObj.Months.OrderBy(x => x.Year).ThenBy(x => x.Month))
                {
                    var filterdSalse = locationFilterdSalse.Where(v => v.LastUpdate != null && month.Year == v.LastUpdate.Year && month.Month == v.LastUpdate.Month).ToList();
                    month.TotalSales = filterdSalse.Count();
                    saleMonths.Add(month);
                }
                if (locationFilterdSalse != null)
                {
                    var saleQueryResult = new SalesQueryResult()
                    {
                        SaleQueryMonths = saleMonths,
                        SalesLocation = location,
                        TotalItems = locationFilterdSalse.Count(),
                        MidItems = saleMonths.Count() > 1 ? saleMonths.Skip(1).Take(saleMonths.Count / 2).FirstOrDefault().TotalSales : saleMonths.FirstOrDefault().TotalSales,
                        AverageItems = saleMonths.Count() > 0 ? locationFilterdSalse.Count() / saleMonths.Count() : 0
                    };
                    result.Add(saleQueryResult);
                }

            }
            return result;
        }

    }
}