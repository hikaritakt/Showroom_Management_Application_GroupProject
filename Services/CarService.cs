using Microsoft.EntityFrameworkCore;
using ShowroomApp.Data;
using ShowroomApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShowroomApp.Services
{
    internal class CarService
    {
        public List<CarDisplayItem> GetAllCars()
        {
            using var context = new AppDbContext();
            return context.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarModel)
                .Include(x => x.Color)
                .Include(x => x.Status)
                .OrderByDescending(x => x.CarId)
                .Select(x => new CarDisplayItem
                {
                    CarId = x.CarId,
                    CarName = x.CarName,
                    BrandName = x.Brand != null ? x.Brand.BrandName : string.Empty,
                    ModelName = x.CarModel != null ? x.CarModel.ModelName : string.Empty,
                    ColorName = x.Color != null ? x.Color.ColorName : string.Empty,
                    StatusName = x.Status != null ? x.Status.StatusName : string.Empty,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
                .ToList();
        }

        public void AddCar(Car car)
        {
            using var context = new AppDbContext();
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            using var context = new AppDbContext();
            var existing = context.Cars.FirstOrDefault(x => x.CarId == car.CarId)
                ?? throw new Exception("Không tìm thấy xe.");

            existing.CarName = car.CarName;
            existing.Price = car.Price;
            existing.Quantity = car.Quantity;
            existing.BrandId = car.BrandId;
            existing.ModelId = car.ModelId;
            existing.ColorId = car.ColorId;
            existing.StatusId = car.StatusId;

            context.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            using var context = new AppDbContext();
            var existing = context.Cars.FirstOrDefault(x => x.CarId == carId)
                ?? throw new Exception("Không tìm thấy xe.");

            context.Cars.Remove(existing);
            context.SaveChanges();
        }
    }
}