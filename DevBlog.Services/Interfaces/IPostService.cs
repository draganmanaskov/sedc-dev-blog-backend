using DevBlog.Domain.Models;
using DevBlog.Dtos.Posts;
using System;


namespace DevBlog.Services.Interfaces
{
    public interface IPostService
    {
        PostDataDto CreatePost(CreatePostDto createPostDto);
        PostDataDto UpdatePost(UpdatePostDto updatePostDto);
        List<PostDataDto> GetAllPosts(int page, int limit, int tagId, string dateTime);
        List<PostDataDto> GetAllUserPosts(int userId);
        PostDataDto GetById(int id, int userId);
        void PostExists(int id);
        void DeletePost(int id);
        double UpdateRating(int id);
        List<PostDataDto> GetTopRatedPosts();
    }
}
