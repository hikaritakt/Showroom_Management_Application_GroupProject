using ShowroomApp.Models;
using ShowroomApp.Repositories;
using ShowroomApp.Shared;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ShowroomApp.Services
{
    public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository();
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Username and password cannot be empty.");

            Account account = _repository.GetByUsername(username);

            if (account == null)
            {
                return false;
            }

            string inputHash = HashPassword(password);
            
            // Check against hashed password stored in DB
            if (account.PasswordHash == inputHash)
            {
                // Set Session
                CurrentUser.UserId = account.AccountId;
                CurrentUser.Username = account.Username;
                CurrentUser.Role = account.Role.RoleName;
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser.UserId = 0;
            CurrentUser.Username = null;
            CurrentUser.Role = null;
        }
    }
}
