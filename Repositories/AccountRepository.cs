using ShowroomApp.Models;
using ShowroomApp.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ShowroomApp.Repositories
{
    public class AccountRepository
    {
        public Account GetByUsername(string username)
        {
            Account account = null;
            using (var connection = DBHelper.GetConnection())
            {
                string query = @"SELECT a.account_id, a.username, a.password_hash, a.role_id, a.employee_id, a.is_active, r.role_name 
                                 FROM Account a 
                                 JOIN Role r ON a.role_id = r.role_id 
                                 WHERE a.username = @Username AND a.is_active = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        account = new Account
                        {
                            AccountId = (int)reader["account_id"],
                            Username = reader["username"].ToString(),
                            PasswordHash = reader["password_hash"].ToString(),
                            RoleId = (int)reader["role_id"],
                            EmployeeId = (int)reader["employee_id"],
                            IsActive = (bool)reader["is_active"],
                            Role = new Role { RoleName = reader["role_name"].ToString() }
                        };
                    }
                }
            }
            return account;
        }

        public List<Account> GetAll() { return new List<Account>(); }
        public Account GetById(int id) { return null; }
        public void Insert(Account account) { }
        public void Update(Account account) { }
        public void Delete(int id) { }
    }
}
