using CursoDotNet.DataAccess.Contracts.Dtos;
using CursoDotNet.DataAccess.Contracts.Entities;
using CursoDotNet.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDotNet.DataAccess.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<CarDto>> GetFilteredByBrand(string brand)
        {
            try
            {
                var query = from u in _dbContext.Cars    
                            where u.brand.ToLower().Contains(brand.Trim().ToLower())
                            orderby u.brand
                            select new CarDto
                            {
                                Id = u.id,
                                Brand = u.brand,
                                Model = u.model,
                                Version = u.Version
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CarDto>> GetAll()
        {
            try
            {
                var response = await _dbContext.Cars
                             .Select(u => new CarDto
                             {
                                 Id = u.id,
                                 Brand = u.brand,
                                 Model = u.model,
                                 Version = u.Version
                             })
                             .ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private List<Car> GetMockCars()
        {
            return new List<Car>
            {
                new Car { brand = "Volkswagen", model = "Golf", Version = "GTI 3P 2017" },
                new Car { brand = "Volkswagen", model = "Golf", Version = "R Variant 2017" },
                new Car { brand = "Seat", model = "Toledo", Version = "2017" },
                new Car { brand = "Lamborghini", model = "Aventador", Version = "Spyder 2015" },
                new Car { brand = "Ford", model = "Mondeo", Version = "SprotBreak 2017" },
                new Car { brand = "Ford", model = "Fiesta", Version = "St 2018" },
                new Car { brand = "Volkswagen", model = "California", Version = "T4 2001" },
                new Car { brand = "Volkswagen", model = "California", Version = "Beach 2.0 2016" },
                new Car { brand = "Seat", model = "Cordoba", Version = "2017" },
                new Car { brand = "Lamborghini", model = "Urus", Version = "4.4 V8" }
            };
        }

        public async Task<CarDto> Add(CarDto newCar)
        {
            try
            {
                Car car = new Car
                {
                    model = newCar.Model,
                    brand = newCar.Brand,
                    Version = newCar.Version,
                    createDateTime = DateTime.Now
                };

                var response = await _dbContext.Cars.AddAsync(car);

                return new CarDto
                {
                    Id = response.Entity.id,
                    Brand = response.Entity.brand,
                    Model = response.Entity.model,
                    Version = response.Entity.Version
                }; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
