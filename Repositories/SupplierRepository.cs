using ShowroomApp.Models;
using ShowroomApp.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace ShowroomApp.Repositories
{
    public class SupplierRepository
    {
        public List<Supplier> GetAll()
        {
            var list = new List<Supplier>();
            using (var connection = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Supplier";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Supplier
                        {
                            SupplierId = (int)reader["supplier_id"],
                            Name = reader["name"].ToString(),
                            Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                            Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : ""
                        });
                    }
                }
            }
            return list;
        }

        public Supplier GetById(int id) { return null; }

        public void Insert(Supplier supplier)
        {
            using (var connection = DBHelper.GetConnection())
            {
                string query = "INSERT INTO Supplier (name, address, phone) VALUES (@Name, @Address, @Phone)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", supplier.Name);
                command.Parameters.AddWithValue("@Address", (object)supplier.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)supplier.Phone ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Supplier supplier)
        {
            using (var connection = DBHelper.GetConnection())
            {
                string query = "UPDATE Supplier SET name=@Name, address=@Address, phone=@Phone WHERE supplier_id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", supplier.SupplierId);
                command.Parameters.AddWithValue("@Name", supplier.Name);
                command.Parameters.AddWithValue("@Address", (object)supplier.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)supplier.Phone ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBHelper.GetConnection())
            {
                string query = "DELETE FROM Supplier WHERE supplier_id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
