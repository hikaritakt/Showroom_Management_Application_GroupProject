using ShowroomApp.Models;
using ShowroomApp.Repositories;
using ShowroomApp.Shared;
using System;
using System.Collections.Generic;

namespace ShowroomApp.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public List<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public void Insert(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new Exception("Employee name is required.");
            
            _repository.Insert(employee);
        }

        public void Update(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new Exception("Employee name is required.");
            _repository.Update(employee);
        }

        public void Delete(int id)
        {
            if (CurrentUser.Role != "Admin")
            {
                throw new UnauthorizedAccessException("Only Admin can delete employees.");
            }
            _repository.Delete(id);
        }
    }
}
