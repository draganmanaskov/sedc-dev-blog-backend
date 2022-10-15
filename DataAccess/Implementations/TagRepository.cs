using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.DataAccess.Implementations
{
    public class TagRepository : ITagRepository
    {
        private DevBlogDbContext _dbContext;
        public TagRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Tag Add(Tag entity)
        {
            _dbContext.Tags.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(Tag entity)
        {
            _dbContext.Tags.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Tag> GetAll()
        {
            return _dbContext.Tags.ToList();
        }

        public List<Tag> GetAllTags(int index)
        {
            if (index == 0)
            {
                return _dbContext.Tags
                 .Include(x => x.Posts)
                 .ThenInclude(y => y.User)
                 .ThenInclude(y => y.Comments)
                 .ToList();
            }
            else
            {
            return _dbContext.Tags.Where(x => x.Id == index)
                .Include(x => x.Posts)
                .ThenInclude(y => y.User)
                .ThenInclude(y => y.Comments)
                .ToList();
            }
        }

        public Tag GetById(int id)
        {
            return _dbContext.Tags.Where(x => x.Id == id)
                .Include(x => x.Posts)
                .ThenInclude(y => y.User)
                .FirstOrDefault();
        }

        public Tag GetTagByValue(string value)
        {
            return _dbContext.Tags.FirstOrDefault(x => x.Value.ToLower() == value.ToLower());
        }

        public Tag Update(Tag entity)
        {
            _dbContext.Tags.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
