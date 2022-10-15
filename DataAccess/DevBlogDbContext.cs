using DevBlog.DataAccess.Configuration;
using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.DataAccess
{
    public class DevBlogDbContext : DbContext
    {
        public DevBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Post>().Navigation(c => c.Tags).AutoInclude();

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());

            modelBuilder.Entity<Post>()
             .HasOne(post => post.User)
             .WithMany(user => user.Posts)
             .HasForeignKey(post => post.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
             .HasOne(comment => comment.User)
             .WithMany(user => user.Comments)
             .HasForeignKey(star => star.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Star>()
                .HasOne(star => star.User)
                .WithMany(user => user.Stars)
                .HasForeignKey(star => star.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Post)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.PostId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Star>()
                .HasOne(star => star.Post)
                .WithMany(post => post.Stars)
                .HasForeignKey(star => star.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
