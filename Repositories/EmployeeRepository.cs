using ShowroomApp.Models;
using ShowroomApp.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace ShowroomApp.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using (var connection = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Employee";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            EmployeeId = (int)reader["employee_id"],
                            Name = reader["name"].ToString(),
                            Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "",
                            Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : ""
                        });
                    }
                }
            }
            return list;
        }

        public Employee GetById(int id) { return null; }

        public void Insert(Employee employee)
        {
            using (var connection = DBHelper.GetConnection())
            {
                string query = "INSERT INTO Employee (name, email, phone) VALUES (@Name, @Email, @Phone)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", (object)employee.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)employee.Phone ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = DBHelper.GetConnection())
            {
                string query = "UPDATE Employee SET name=@Name, email=@Email, phone=@Phone WHERE employee_id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", employee.EmployeeId);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", (object)employee.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)employee.Phone ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBHelper.GetConnection())
            {
                string query = "DELETE FROM Employee WHERE employee_id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
