using ShowroomApp.Data;
using ShowroomApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShowroomApp.Services
{
    internal class AccessoryService
    {
        public List<Accessory> GetAllAccessories()
        {
            using var context = new AppDbContext();
            return context.Accessories
                .OrderByDescending(x => x.AccessoryId)
                .ToList();
        }

        public void AddAccessory(Accessory accessory)
        {
            using var context = new AppDbContext();
            context.Accessories.Add(accessory);
            context.SaveChanges();
        }

        public void UpdateAccessory(Accessory accessory)
        {
            using var context = new AppDbContext();
            var existing = context.Accessories.FirstOrDefault(x => x.AccessoryId == accessory.AccessoryId)
                ?? throw new Exception("Không tìm thấy phụ kiện.");

            existing.AccessoryName = accessory.AccessoryName;
            existing.UnitPrice = accessory.UnitPrice;
            existing.Quantity = accessory.Quantity;
            existing.Description = accessory.Description;

            context.SaveChanges();
        }

        public void DeleteAccessory(int accessoryId)
        {
            using var context = new AppDbContext();
            var existing = context.Accessories.FirstOrDefault(x => x.AccessoryId == accessoryId)
                ?? throw new Exception("Không tìm thấy phụ kiện.");

            context.Accessories.Remove(existing);
            context.SaveChanges();
        }
    }
}