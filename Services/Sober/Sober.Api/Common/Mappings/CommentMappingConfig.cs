using Mapster;
using Sober.Application.Pages.Comments.Commands;
using Sober.Contracts.Request.Comments;
using Sober.Contracts.Response.Comments;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Api.Common.Mappings
{
    public class CommentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CommentRequest Request, Guid PostId), CreateCommentCommand>()
                .Map(dest => dest.PostId, src => src.PostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Comment, CommentResponse>()
                .Map(dest => dest.CommentId, src => src.Id.Value)
                .Map(dest => dest.PostId, src => src.PostId.Value)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Comments, src => src.Comments);
        }
    }
}
