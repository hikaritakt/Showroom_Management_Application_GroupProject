using ShowroomApp.Data;
using ShowroomApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShowroomApp.Services
{
    internal class LookupService
    {
        public List<Brand> GetBrands()
        {
            using var context = new AppDbContext();
            return context.Brands.OrderBy(x => x.BrandName).ToList();
        }

        public List<CarModel> GetModels()
        {
            using var context = new AppDbContext();
            return context.CarModels.OrderBy(x => x.ModelName).ToList();
        }

        public List<Color> GetColors()
        {
            using var context = new AppDbContext();
            return context.Colors.OrderBy(x => x.ColorName).ToList();
        }

        public List<CarStatus> GetStatuses()
        {
            using var context = new AppDbContext();
            return context.CarStatuses.OrderBy(x => x.StatusName).ToList();
        }

        public List<Car> GetCars()
        {
            using var context = new AppDbContext();
            return context.Cars.OrderBy(x => x.CarName).ToList();
        }

        public List<Accessory> GetAccessories()
        {
            using var context = new AppDbContext();
            return context.Accessories.OrderBy(x => x.AccessoryName).ToList();
        }
    }
}