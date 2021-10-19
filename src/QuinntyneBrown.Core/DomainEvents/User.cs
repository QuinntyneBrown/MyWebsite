using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateUser
    {
        public Guid UserId { get; private set; } = Guid.NewGuid();
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public CreateUser(string fullname, string username, string password)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
        }
    }

    public class AddRefreshToken
    {
        public string RefreshToken { get; private set; }

        public AddRefreshToken(string token)
        {
            RefreshToken = token;
        }
    }
}
