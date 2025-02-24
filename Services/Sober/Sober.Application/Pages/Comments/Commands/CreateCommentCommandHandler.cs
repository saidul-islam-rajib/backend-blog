using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;

namespace Sober.Application.Pages.Comments.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ErrorOr<Comment>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public async Task<ErrorOr<Comment>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Get post information by it's ID
            Post response = await _postRepository.GetPostByIdAsync(request.PostId);
            if(response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            // Create comment
            Comment comment = Comment.Create(
                PostId.Create(request.PostId),
                request.Name,
                request.Comments,
                response.PostTitle);

            // Persist comment into DB
            _commentRepository.CreateComment(comment);

            // Return comment
            return comment;
        }
    }
}
