using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using DevBlog.Dtos.Tags;
using DevBlog.Mappers;
using Microsoft.EntityFrameworkCore;


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
               .FirstOrDefault();
        }

        public Post GetByIdPost(int id, int userId)
        {
            return _dbContext.Posts.Where(x => x.Id == id)
               .Include(x => x.User)
               .Include(x => x.Tags)
               .Include(x => x.Comments)
               .Include(x => x.Stars.Where(x => x.Id == userId))
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
    }
}
