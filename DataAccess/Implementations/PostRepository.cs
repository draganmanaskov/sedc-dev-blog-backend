using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.DataAccess.Implementations
{
    public class PostRepository : IPostRepository
    {
        private DevBlogDbContext _dbContext;
        public PostRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Post entity)
        {
            _dbContext.Posts.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Post entity)
        {
            _dbContext.Posts.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Post> GetAll()
        {
            return _dbContext.Posts.ToList();
        }

        public List<Post> GetAllByUser(int userId)
        {
            return _dbContext.Posts.Where(x => x.UserId == userId)
                .Include(x => x.User)
                .ToList();
        }

        public Post GetById(int id)
        {
            return _dbContext.Posts.Where(x => x.Id == id)
                .Include(x => x.User)
                .Include(x => x.Comments)
                .FirstOrDefault();
        }

        public void Update(Post entity)
        {
            _dbContext.Posts.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
