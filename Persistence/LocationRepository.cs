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
    public class LocationRepository : ILocationRepository
    {
        private readonly ElectronicCarsDbContext context;

        public LocationRepository(ElectronicCarsDbContext context)
        {
            this.context = context;
        }

        public async Task<SalesLocation> GetSaleLocation(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.SalesLocations.FindAsync(id);

            return await context.SalesLocations
              .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(SalesLocation location)
        {
            context.SalesLocations.Add(location);
        }

        public void Remove(SalesLocation location)
        {
            context.Remove(location);
        }

        public async Task<QueryResult<SalesLocation>> GetSalesLocation()
        {
            var result = new QueryResult<SalesLocation>();
            var query = context.SalesLocations
              .AsQueryable();
            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();
            return result;
        }

    }
}