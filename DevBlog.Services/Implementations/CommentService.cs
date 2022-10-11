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

        public CommentDataDto CreateComment(CreateCommentDto createCommentDto)
        {
            var post = _postRepository.GetById(createCommentDto.PostId);
            if (post == null)
            {
                throw new PostNotFoundException($"Post with id {createCommentDto.PostId} does not exist!");
            }
            var user = _userRepository.GetById(createCommentDto.UserId);
            if (user == null)
            {
                throw new UserNotFoundException("User does not exist!");
            }
            var createdComment = _commentRepository.Add(createCommentDto.ToComment());

            return createdComment.ToCommentDataDto();

        }

        public void DeleteComment(int id, int loggedInUserId)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                throw new CommentNotFoundException($"Comment with id: {id} does not exist"); 
            }
            if (comment.UserId != loggedInUserId)
            {
                throw new UnauthorizedAccessException("User not authorized to make changes");
            }
            _commentRepository.Delete(comment);
        }

        public CommentDataDto UpdateComment(UpdateCommentDto updateCommentDto, int loggedInUserId)
        {
            var comment = _commentRepository.GetById(updateCommentDto.Id);
            if (comment == null)
            {
                throw new CommentNotFoundException($"Comment with id: {updateCommentDto.Id} does not exist");
            }
            if (comment.UserId != loggedInUserId)
            {
                throw new UnauthorizedAccessException("User not authorized to make changes");
            }
            comment.Body = updateCommentDto.Body;
            var updatedComment = _commentRepository.Update(comment);

            return updatedComment.ToCommentDataDto();
        }
    }
}
