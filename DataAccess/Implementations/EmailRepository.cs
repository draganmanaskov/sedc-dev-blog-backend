using DevBlog.DataAccess.Interfaces;
using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Implementations
{
    public class EmailRepository : IEmailRepository
    {
        private DevBlogDbContext _dbContext;
        public EmailRepository(DevBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Email Add(Email entity)
        {
            _dbContext.Emails.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(Email entity)
        {
            _dbContext.Emails.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Email> GetAll()
        {
            return _dbContext.Emails.ToList();
        }

        public Email GetByEmail(string emailAddress)
        {
            return _dbContext.Emails.FirstOrDefault(x => x.Address.ToLower() == emailAddress.ToLower());
        }

        public Email GetById(int id)
        {
            return _dbContext.Emails.FirstOrDefault(x => x.Id == id);
        }

        public Email Update(Email entity)
        {
            _dbContext.Emails.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
