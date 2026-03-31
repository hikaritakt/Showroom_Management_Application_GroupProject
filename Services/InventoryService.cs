using Microsoft.EntityFrameworkCore;
using ShowroomApp.Data;
using ShowroomApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShowroomApp.Services
{
    internal class InventoryService
    {
        public List<InventoryDisplayItem> GetCarTransactions()
        {
            using var context = new AppDbContext();
            return context.CarInventoryTransactions
                .Include(x => x.Car)
                .OrderByDescending(x => x.TransactionDate)
                .Select(x => new InventoryDisplayItem
                {
                    TransactionId = x.TransactionId,
                    ItemId = x.CarId,
                    ItemName = x.Car != null ? x.Car.CarName : string.Empty,
                    TransactionType = x.TransactionType,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Note = x.Note ?? string.Empty,
                    TransactionDate = x.TransactionDate
                })
                .ToList();
        }

        public List<InventoryDisplayItem> GetAccessoryTransactions()
        {
            using var context = new AppDbContext();
            return context.AccessoryInventoryTransactions
                .Include(x => x.Accessory)
                .OrderByDescending(x => x.TransactionDate)
                .Select(x => new InventoryDisplayItem
                {
                    TransactionId = x.AccessoryTransactionId,
                    ItemId = x.AccessoryId,
                    ItemName = x.Accessory != null ? x.Accessory.AccessoryName : string.Empty,
                    TransactionType = x.TransactionType,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Note = x.Note ?? string.Empty,
                    TransactionDate = x.TransactionDate
                })
                .ToList();
        }

        public void ImportCar(int carId, int quantity, decimal unitPrice, string? note)
        {
            using var context = new AppDbContext();
            var car = context.Cars.FirstOrDefault(x => x.CarId == carId)
                ?? throw new Exception("Không tìm thấy xe.");

            context.CarInventoryTransactions.Add(new CarInventoryTransaction
            {
                CarId = carId,
                TransactionType = "IMPORT",
                Quantity = quantity,
                UnitPrice = unitPrice,
                Note = note,
                TransactionDate = DateTime.Now
            });

            car.Quantity += quantity;
            context.SaveChanges();
        }

        public void ExportCar(int carId, int quantity, decimal unitPrice, string? note)
        {
            using var context = new AppDbContext();
            var car = context.Cars.FirstOrDefault(x => x.CarId == carId)
                ?? throw new Exception("Không tìm thấy xe.");

            if (car.Quantity < quantity)
}