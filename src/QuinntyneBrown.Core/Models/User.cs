using QuinntyneBrown.Core.DomainEvents;
using QuinntyneBrown.Core.Interfaces;
using System;
using System.Security.Cryptography;

namespace QuinntyneBrown.Core.Models
{
    public class User : AggregateRoot
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

        protected override void When(dynamic @event) => When(@event);

        private void when(AddRefreshToken @event)
        {
            RefreshToken = @event.RefreshToken;
        }

        protected override void EnsureValidState()
        {
        }
    }
}
