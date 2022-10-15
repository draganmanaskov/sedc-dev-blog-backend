using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Tags;
using DevBlog.Mappers;
using Microsoft.EntityFrameworkCore;
using XAct;

namespace DevBlog.DataAccess.Implementations
{
    public class PostRepository : IPostRepository
    {
        private DevBlogDbContext _dbContext;
        public PostRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post Add(Post entity)
        {
            _dbContext.Posts.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(Post entity)
        {
            _dbContext.Posts.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Post> GetAll()
        {
            return _dbContext.Posts
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(X => X.Comments)
                .ThenInclude(y => y.User)
                .ToList();
        }
        public List<Post> GetAllDefault(int skip, int limit)
        {
            return _dbContext.Posts
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(X => X.Comments) 
                .ThenInclude(y => y.User)
                .OrderBy(x => x.CreatedAt)
                .Skip(skip)
                .Take(limit)
                .ToList();
        }

        public List<Post> GetAllTime(int skip, int limit, DateTime date)
        {
            return _dbContext.Posts
                .Where(x => x.CreatedAt.Month == date.Month && x.CreatedAt.Year == date.Year)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(X => X.Comments)
                .ThenInclude(y => y.User)
                .Skip(skip)
                .Take(limit)
                .ToList();
        }

        public List<Post> GetAllTag(int skip, int limit, Tag tag)
        {
            return _dbContext.Posts
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(X => X.Comments)
                .ThenInclude(y => y.User)
                .Where(x => x.Tags.Contains(tag))
                .Skip(skip)
                .Take(limit)
                .ToList();
        }

        public List<Post> GetAllTagAndTime(int skip, int limit, Tag tag, DateTime date)
        {
            return _dbContext.Posts
                .Where(x => x.CreatedAt.Month == date.Month && x.CreatedAt.Year == date.Year)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(X => X.Comments)
                .ThenInclude(y => y.User)
                .Where(x => x.Tags.Contains(tag))
                .Skip(skip)
                .Take(limit)
                .ToList();
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
               .Include(x => x.Tags)
               .Include(x => x.Comments)
               .ThenInclude(y => y.User)
               .FirstOrDefault();
        }

        public Post GetByIdDelete(int id)
        {
            return _dbContext.Posts.Where(x => x.Id == id)
               .FirstOrDefault();
        }

        public Post GetByIdPost(int id, int userId)
        {
            return _dbContext.Posts.Where(x => x.Id == id)
               .Include(x => x.User)
               .Include(x => x.Tags)
               .Include(x => x.Comments)
               .ThenInclude(y => y.User)
               .Include(x => x.Stars.Where(x => x.UserId == userId))
               .FirstOrDefault();
        }

        public Post GetByIdForStars(int id)
        {
            return _dbContext.Posts.Where(x => x.Id == id)
               .Include(x => x.Stars)
               .FirstOrDefault();
        }

        public Post Update(Post entity)
        {
            _dbContext.Posts.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public List<Post> GetTopFourRated()
        {
            return _dbContext.Posts
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(X => X.Comments)
                .ThenInclude(y => y.User)
                .OrderByDescending(x => x.Rating)
                .Take(4)
                .ToList();
        }
    }
}
