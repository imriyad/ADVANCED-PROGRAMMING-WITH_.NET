using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.interfaces;
using CRMSystem.DAL.interfaces;
using CRMSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public UserDTO Authenticate(string email, string password)
        {
            var user = _repo.GetByEmail(email);
            if (user == null)
                return null;

            // Hash incoming password and compare
            var hashedPassword = ComputeSha256Hash(password);
            if (user.PasswordHash != hashedPassword)
                return null;

            // Authentication successful
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role
            };
        }

        public void Register(RegisterRequestDTO registerRequest)
        {
            // Check if user already exists
            var existingUser = _repo.GetByEmail(registerRequest.Email);
            if (existingUser != null)
                throw new Exception("User already exists.");

            // Hash password
            var hashedPassword = ComputeSha256Hash(registerRequest.Password);

            // Create new User entity
            var newUser = new User
            {
                Email = registerRequest.Email,
                PasswordHash = hashedPassword,
                FullName = registerRequest.FullName,
                Role = registerRequest.Role
            };

            // Save to database
            _repo.Add(newUser);
        }


        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to string
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
