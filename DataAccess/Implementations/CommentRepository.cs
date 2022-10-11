using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.DataAccess.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private DevBlogDbContext _dbContext;
        public CommentRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Comment Add(Comment entity)
        {
            _dbContext.Comments.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(Comment entity)
        {
            _dbContext.Comments.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _dbContext.Comments.ToList();
        }

        public List<Comment> GetAllByUser(int userId)
        {
            return _dbContext.Comments.Where(x => x.UserId == userId)
                .Include(x => x.Post)
                .ToList();
        }

        public Comment GetById(int id)
        {
            return _dbContext.Comments.FirstOrDefault(x => x.Id == id);
        }

        public Comment Update(Comment entity)
        {
            _dbContext.Comments.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
