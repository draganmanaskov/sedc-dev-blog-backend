using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private DevBlogDbContext _dbContext;
        public UserRepository(DevBlogDbContext devBlogDbContext)
        {
            _dbContext = devBlogDbContext;
        }

        public User Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users
                .Include(x => x.Posts).ThenInclude(y => y.Comments)
                .Include(x => x.Posts).ThenInclude(y => y.Tags)
                .FirstOrDefault(x => x.Id == id);
        }

        public User GetByIdPost(int id)
        {
            return _dbContext.Users
                .Include(x => x.Posts)
                .Include(x => x.Posts).ThenInclude(y => y.Tags)
                .FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public User LoginUser(string username, string hashedPassword)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == hashedPassword);
        }

        public User Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
