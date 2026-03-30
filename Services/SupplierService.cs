using ShowroomApp.Models;
using ShowroomApp.Repositories;
using ShowroomApp.Shared;
using System;
using System.Collections.Generic;

namespace ShowroomApp.Services
{
    public class SupplierService
    {
        private readonly SupplierRepository _repository;

        public SupplierService()
        {
            _repository = new SupplierRepository();
        }

        public List<Supplier> GetAll()
        {
            return _repository.GetAll();
        }

        public void Insert(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new Exception("Supplier name is required.");

            _repository.Insert(supplier);
        }

        public void Update(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new Exception("Supplier name is required.");
            _repository.Update(supplier);
        }

        public void Delete(int id)
        {
            if (CurrentUser.Role != "Admin")
            {
                throw new UnauthorizedAccessException("Only Admin can delete suppliers.");
            }
            _repository.Delete(id);
        }
    }
}
