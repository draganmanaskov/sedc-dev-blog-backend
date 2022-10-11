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
    public class StarRepository : IStarRepository
    {
        private DevBlogDbContext _dbContext;
        public StarRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Star Add(Star entity)
        {
            _dbContext.Stars.Update(entity);
            _dbContext.SaveChanges();

            return entity;
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

        public Star Update(Star entity)
        {
            _dbContext.Stars.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        // No use for now
        public List<Star> GetAll()
        {
            throw new NotImplementedException();
        }

        public Star GetById(int id)
        {
            return _dbContext.Stars.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
