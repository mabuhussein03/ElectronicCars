using ElectronicCars.Core;
using System.Threading.Tasks;
namespace ElectronicCars.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElectronicCarsDbContext context;

        public UnitOfWork(ElectronicCarsDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}