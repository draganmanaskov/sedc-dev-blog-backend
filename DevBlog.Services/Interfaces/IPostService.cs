using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;


namespace DevBlog.Services.Interfaces
{
    public interface IPostService
    {
        PostDataDto CreatePost(CreatePostDto createPostDto);
        PostDataDto UpdatePost(UpdatePostDto updatePostDto);
        List<PostDataDto> GetAllPosts(int page, int limit, int tagId, int year, int month);
        List<PostDataDto> GetAllUserPosts(int userId);
        PostDataDto GetById(int id, int userId);
        void PostExists(int id);
        double UpdateRating(int id);
    }
}
