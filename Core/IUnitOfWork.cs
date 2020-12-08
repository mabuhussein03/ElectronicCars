using System;
using System.Threading.Tasks;

namespace ElectronicCars.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}