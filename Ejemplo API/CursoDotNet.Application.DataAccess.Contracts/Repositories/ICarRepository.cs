using CursoDotNet.DataAccess.Contracts.Dtos;
using CursoDotNet.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoDotNet.DataAccess.Contracts.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<CarDto>> GetFilteredByBrand(string brand);
        Task<List<CarDto>> GetAll();
        Task<CarDto> Add(CarDto newCar);
    }
}
