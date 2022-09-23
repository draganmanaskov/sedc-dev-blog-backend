using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.DataAccess.Implementations
{
    public class StarRepository : IStarRepository
    {
        private DevBlogDbContext _dbContext;
        public StarRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Star entity)
        {
            _dbContext.Stars.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Star entity)
        {
            _dbContext.Stars.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Star GetStarByPostAndUserId(int postId, int userId)
        {
            return _dbContext.Stars.FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
        }

        public void Update(Star entity)
        {
            _dbContext.Stars.Update(entity);
            _dbContext.SaveChanges();
        }

        // No use for now
        public List<Star> GetAll()
        {
            throw new NotImplementedException();
        }

        public Star GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
