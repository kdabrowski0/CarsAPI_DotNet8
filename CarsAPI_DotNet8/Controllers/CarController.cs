using CarsAPI_DotNet8.Data;
using CarsAPI_DotNet8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // TODO later on add repositories and services so its not that fat
        private readonly DataContext _db;

        public CarController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _db.Cars.ToListAsync();
            
            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound("Car not found");
            }

            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            _db.Cars.Add(car);
            await _db.SaveChangesAsync();
            return Ok(await _db.Cars.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(Car updatedCar)
        {
            var car = _db.Cars.Find(updatedCar.Id);
            if (car == null)
            {
                return NotFound($"Car of id: {updatedCar.Id} not found");
            }

            if (!string.IsNullOrWhiteSpace(updatedCar.Make))
            {
                car.Make = updatedCar.Make;
            }
            if (!string.IsNullOrWhiteSpace(updatedCar.Model))
            {
                car.Model = updatedCar.Model;
            }
            if (updatedCar.Year != 0)
            {
                car.Year = updatedCar.Year;
            }
            if (!string.IsNullOrWhiteSpace(updatedCar.Color))
            {
                car.Color = updatedCar.Color;
            }


            await _db.SaveChangesAsync();
            return Ok(await _db.Cars.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound("Car not found");
            }
            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();

            return Ok(await _db.Cars.ToListAsync());
        }
    }
}
