using CursoDotNet.Application.BusinessModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoDotNet.Application.Contracts.Services
{
    public interface ICarService
    {
        Task<List<CarModel>> GetAllCars();

        Task<List<CarModel>> GetCarsFilteredByBrand(string brand);

        Task<List<CarModel>> GetAllCarsCached();

        Task<CarModel> AddCar(CarModel newCar);

    }
}
