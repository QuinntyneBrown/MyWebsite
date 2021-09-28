using System;

namespace QuinntyneBrown.Core.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(Byte[] salt, string password);
    }
}
