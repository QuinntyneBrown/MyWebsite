using QuinntyneBrown.Api.Core;
using System;
using System.Security.Cryptography;

namespace QuinntyneBrown.Api.Models
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public byte[] Salt { get; private set; } = new byte[128 / 8];
        public User(string fullname, string username, string password, IPasswordHasher passwordHasher)
            : this()
        {
            Fullname = fullname;
            Username = username;
            Password = passwordHasher.HashPassword(Salt, password);
        }

        private User()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(Salt);
            }
        }

        public string RefreshToken { get; private set; }
        public User AddRefreshToken(string token)
        {
            RefreshToken = token;
            return this;
        }
    }
}
