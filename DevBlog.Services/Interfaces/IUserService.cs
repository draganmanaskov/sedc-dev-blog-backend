using DevBlog.Domain.Models;
using DevBlog.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        LoggedUserDataDto RegisterUser(RegisterUserDto registerUserDto);
        LoggedUserDataDto LoginUser(LoginUserDto loginDto);
        string GetJWT(User user);
        void ValidateUser(RegisterUserDto registerUserDto);
        string HashPassword(string password);
        User GetUserById(int id);
    }
}
