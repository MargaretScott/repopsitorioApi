using AutoMapper;
using CursoDotNet.Application.BusinessModels.Models;
using CursoDotNet.Application.Contracts.Services;
using CursoDotNet.CrossCutting.Contracts.Services;
using CursoDotNet.DataAccess.Contracts;
using CursoDotNet.DataAccess.Contracts.Dtos;
using CursoDotNet.DataAccess.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoDotNet.Application.Services
{
    [Authorize]
    public class CarService : ICarService
    {
        private readonly ICacheService _cacheService;
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarService(ICarRepository carRepository, ICacheService cacheService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<List<CarModel>> GetCarsFilteredByBrand(string brand)
        {
            var resultado = new List<CarModel>();
            try
            {
                var carsDto = await _carRepository.GetAsync(x => x.brand == brand);

                resultado = _mapper.Map<List<CarModel>>(carsDto);

            }
            catch (Exception oException)
            {
                throw oException;
            }

            return resultado;
        }

        public async Task<List<CarModel>> GetAllCarsCached()
        {            
            var resultado = new List<CarModel>();
            try
            { 
                var cacheKey = $"GetCarsPagedCached";
                var carsDto = await _cacheService.GetUsingCache(cacheKey, async () => await _carRepository.GetAll());
                foreach (var item in carsDto)
                {
                    var oCar = _mapper.Map<CarModel>(item);
                    resultado.Add(oCar);
                }
            
            }
            catch (Exception oException)
            {
                throw oException;
            }

            return resultado;
        }

        public async Task<List<CarModel>> GetAllCars()
        {
            var resultado = new List<CarModel>();
            try
            {               
                var carsDto = await _carRepository.GetAll();
                foreach (var item in carsDto)
                {
                    var oCar = _mapper.Map<CarModel>(item);
                    resultado.Add(oCar);
                }

            }
            catch (Exception oException)
            {
                throw oException;
            }

            return resultado;
        }

        public async Task<CarModel> AddCar(CarModel newCar)
        {
            try
            {
                var _newCar = _mapper.Map<CarDto>(newCar);
                var response = await _carRepository.Add(_newCar);
                _unitOfWork.Commit();
            }
            catch (Exception oException)
            {
                throw oException;
            }

            return newCar;
        }
    }
}
