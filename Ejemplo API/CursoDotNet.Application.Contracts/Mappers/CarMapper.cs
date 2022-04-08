using CursoDotNet.Application.BusinessModels.Models;
using CursoDotNet.DataAccess.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDotNet.Application.Contracts.Mappers
{
    public static class CarMapper
    {
        public static CarModel Map(CarDto carDto)
        {
            return new CarModel
            {
                Brand = carDto.Brand,
                Model = carDto.Model,
                Id = carDto.Id,
                Version = carDto.Version
            };
        }
    }
}
