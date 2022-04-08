using AutoMapper;
using CursoDotNet.Application.BusinessModels.Models;
using CursoDotNet.Application.BusinessModels.Requests;
using CursoDotNet.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CursoDotNet.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        public CarController(ICarService actuacionService, IMapper mapper)
        {
            _carService = actuacionService;
            _mapper = mapper;
        }

        //GET api​/Car​/GetAllCars
        [HttpGet]
        [Route("GetAllCars")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _carService.GetAllCars();

            return Ok(response);
        }

        //POST api/Car/GetCarsFilteredByBrand
        [HttpPost]
        [Route("GetCarsFilteredByBrand")]
        public async Task<ActionResult> GetCarsFilteredByBrand(string brand)
        {
            var response = await _carService.GetCarsFilteredByBrand(brand);

            return Ok(response);
        }

        //GET api/Car/GetCarsCached
        [HttpGet]
        [Route("GetCarsCached")]
        public async Task<ActionResult> GetCached()
        {
            var response = await _carService.GetAllCarsCached();

            return Ok(response);
        }

        //POST api/Car/AddCar
        [HttpPost]
        [Route("AddCar")]
        public async Task<ActionResult> Add([FromBody]CreateCarRequest newCar)
        {

            //validar que no este vacio
            //hacer un throw
            //autommaper al carModel del negocio.
            var car = _mapper.Map<CarModel>(newCar);
            var response = await _carService.AddCar(_mapper.Map<CarModel>(newCar));

            return Ok(response);
        }
    }

}