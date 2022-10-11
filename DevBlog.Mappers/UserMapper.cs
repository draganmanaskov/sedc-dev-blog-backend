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
                Role = "User",
                Password = hashedPassword,
            };
        }

        public static LoggedUserDataDto ToLoggedUserDataDto(this User user, string token)
        {
            return new LoggedUserDataDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username= user.Username,
                Role = user.Role,
                Token = token,
            };
        }

        public static UserInfoDto ToUserInfoDto(this User user)
        {
            return new UserInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
            };
        }
        
    }
}
