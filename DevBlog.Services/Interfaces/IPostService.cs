using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;


namespace DevBlog.Services.Interfaces
{
    public interface IPostService
    {
        PostDataDto CreatePost(CreatePostDto createPostDto);
        List<PostDataDto> GetAllPosts();
        PostDataDto GetById(int id);
        void PostExists(int id);
        double UpdateRating(int id);
    }
}
