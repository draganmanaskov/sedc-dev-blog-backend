using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

using XSystem.Security.Cryptography;

namespace DevBlog.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        Username = "Admin1",
                        Role = "Admin",
                        Password = HashPassword("admin1"),                   
                    }
                );
        }

        public string HashPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            return Encoding.ASCII.GetString(hashBytes);

        }
    }
}
