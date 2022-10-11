using DevBlog.DataAccess;
using DevBlog.DataAccess.Implementations;
using DevBlog.DataAccess.Interfaces;
using DevBlog.Services.Implementations;
using DevBlog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevBlog.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<NotesAppDbContext>(x =>
            //x.UseSqlServer("Server=10.10.10.10;Database=NotesAppDb;Trusted_Connection=True"));
            //x.UseSqlServer("Server=.\\SQLEXPRESS;Database=NotesAppDb;Trusted_Connection=True"));

            services.AddDbContext<DevBlogDbContext>(x =>
            x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStarRepository, StarRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IStarService, StarService>();
        }
    }
}
