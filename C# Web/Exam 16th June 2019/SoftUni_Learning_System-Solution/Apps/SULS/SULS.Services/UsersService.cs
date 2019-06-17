﻿using SULS.Data;
using SULS.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private readonly SULSContext db;

        public UsersService(SULSContext db)
        {
            this.db = db;
        }
        public string CreateUser(string username, string email, string password)
        {
            if (db.Users.Any(u => u.Username == username))
            {
                throw new ArgumentException("Username already taken! Please try again with another username!");
            }

            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public User GetUserOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);

            var user = this.db.Users.FirstOrDefault(
                x => x.Username == username
                && x.Password == passwordHash);

            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
