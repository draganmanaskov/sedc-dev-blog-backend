using DevBlog.Domain.Models;
using DevBlog.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this RegisterUserDto registerUserDto, string hashedPassword)
        {
            return new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Password = hashedPassword
            };
        }
    }
}
