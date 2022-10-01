using DevBlog.DataAccess.Implementations;
using DevBlog.DataAccess.Interfaces;
using DevBlog.Dtos.Comments;
using DevBlog.Mappers;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public CommentService(ICommentRepository commentRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public void CreateComment(CreateCommentDto createCommentDto)
        {
            var post = _postRepository.GetById(createCommentDto.PostId);
            if (post == null)
            {
                throw new PostNotFoundException($"Post with id {createCommentDto.PostId} does not exist!");
            }
            var user = _userRepository.GetById(createCommentDto.UserId);
            if (user == null && createCommentDto.UserId != 0)
            {
                throw new UserNotFoundException("User does not exist!");
            }
            _commentRepository.Add(createCommentDto.ToComment());
        }

        public void DeleteComment(int id, int loggedInUserId)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                throw new NotImplementedException(); // replace with CommentNotFoundException
            }
            if (comment.UserId != loggedInUserId)
            {
                throw new NotImplementedException(); // replace with UnauthorizedUserException
            }
            _commentRepository.Delete(comment);
        }

        public void UpdateComment(UpdateCommentDto updateCommentDto, int loggedInUserId)
        {
            var comment = _commentRepository.GetById(updateCommentDto.Id);
            if (comment == null)
            {
                throw new NotImplementedException(); // replace with CommentNotFoundException
            }
            if (comment.UserId != loggedInUserId)
            {
                throw new NotImplementedException(); // replace with UnauthorizedUserException
            }
            comment.Body = updateCommentDto.Body;
            _commentRepository.Update(comment);
        }
    }
}
