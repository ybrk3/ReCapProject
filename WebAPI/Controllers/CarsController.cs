using Business.Abstract;
using Entities.Concrete;
using Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarSevice _carService;
        public CarsController(ICarSevice carService)
        {
            _carService = carService;
        }

        [HttpPost("addcar")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecar")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletecar")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var cars = _carService.GetCarsByBrandId(brandId);
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var cars = _carService.GetCarsByColorId(colorId);
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }

        [HttpGet("getcarsbybrandiddetail")]
        public IActionResult GetCarsByBrandIdDetail(int brandId)
        {
            var cars= _carService.GetCarsByBrandIdDetail(brandId);
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }

        [HttpGet("getcarsbycoloriddetail")]
        public IActionResult GetCarsByColorIdDetail(int colorId)
        {
            var cars = _carService.GetCarsByColorIdDetail(colorId);
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }

        [HttpGet("getallcardetail")]
       public IActionResult GetAllCarDetail()
        {
            var cars = _carService.GetAllCarDetail();
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var cars= _carService.GetById(carId);
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }

        [HttpGet("getcarsbybrandandcoloriddetail")]
        public IActionResult GetCarsByBrandAndColorIdDetail(int brandId, int colorId)
        {
            var cars= _carService.GetCarsByBrandAndColorIdDetail(brandId, colorId);
            if (cars.Success)
            {
                return Ok(cars.Data);
            }
            return BadRequest(cars.Message);
        }



    }
}
