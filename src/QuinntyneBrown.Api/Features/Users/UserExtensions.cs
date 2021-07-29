using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new()
            {
                UserId = user.UserId,
                Fullname = user.Fullname,
                Username = user.Username
            };
        }
    }
}
