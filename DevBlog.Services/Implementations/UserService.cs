using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Users;
using DevBlog.Mappers;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace DevBlog.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public LoggedUserDataDto LoginUser(LoginUserDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Username) && string.IsNullOrEmpty(loginDto.Password))
            {
                throw new UserDataException("Username and password are required fields!");
            }

            if (string.IsNullOrEmpty(loginDto.Username))
            {
                throw new UserDataException("Username is required!");
            }

            if (string.IsNullOrEmpty(loginDto.Password))
            {
                throw new UserDataException("Password is required!");
            }

            User userDb = _userRepository.LoginUser(loginDto.Username, HashPassword(loginDto.Password));

            if (userDb == null)
            {
                throw new UserNotFoundException("User not found");
            }

            //JWT 
            string jwt = GetJWT(userDb);

            return userDb.ToLoggedUserDataDto(jwt);

        }

        public LoggedUserDataDto RegisterUser(RegisterUserDto registerUserDto)
        {
            ValidateUser(registerUserDto);

            var user = registerUserDto.ToUser(HashPassword(registerUserDto.Password));

            _userRepository.Add(user);

            User userDb = _userRepository.LoginUser(registerUserDto.Username, HashPassword(registerUserDto.Password));

            if (userDb == null)
            {
                throw new UserNotFoundException("User not found");
            }

            //JWT 
            string jwt = GetJWT(userDb);

            return userDb.ToLoggedUserDataDto(jwt);
        }

        public string GetJWT(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_config["AppSettings:SecretKey"]);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                   SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(
                   new[]
                   {
                       new Claim(ClaimTypes.Name, user.Username),
                       new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                       new Claim(ClaimTypes.Role, user.Role)
                   }
               )
            };

            SecurityToken token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public void ValidateUser(RegisterUserDto registerUserDto)
        {
            if (string.IsNullOrEmpty(registerUserDto.Username) || string.IsNullOrEmpty(registerUserDto.Password))
            {
                throw new UserDataException("Username and password are required fields!");
            }
            if (string.IsNullOrEmpty(registerUserDto.ConfirmPassword))
            {
                throw new UserDataException("Please confirm password!");
            }
            if (registerUserDto.Username.Length > 40)
            {
                throw new UserDataException("Username: Maximum length for username is 40 characters");
            }
            if (!string.IsNullOrEmpty(registerUserDto.FirstName) && registerUserDto.FirstName.Length > 50)
            {
                throw new UserDataException("Maximum length for FirstName is 50 characters");
            }
            if (!string.IsNullOrEmpty(registerUserDto.LastName) && registerUserDto.LastName.Length > 50)
            {
                throw new UserDataException("Maximum length for LastName is 50 characters");
            }
            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new UserDataException("Passwords must match!");
            }

            var userDb = _userRepository.GetUserByUsername(registerUserDto.Username);

            if (userDb != null)
            {
                throw new UserDataException($"Username:{registerUserDto.Username} is already in use!");
            }

        }

        public string HashPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            return Encoding.ASCII.GetString(hashBytes);

        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {id} does not exist!");
            }
            return user;
        }
    }
}
