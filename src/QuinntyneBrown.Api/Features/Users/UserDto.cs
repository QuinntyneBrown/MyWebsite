using System;

namespace QuinntyneBrown.Api.Features
{
    public class UserDto
    {
        public string Fullname { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
