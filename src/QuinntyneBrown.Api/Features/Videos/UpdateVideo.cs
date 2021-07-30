using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class UpdateVideo
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Video).NotNull();
                RuleFor(request => request.Video).SetValidator(new VideoValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public VideoDto Video { get; set; }
        }

        public class Response : ResponseBase
        {
            public VideoDto Video { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var video = await _context.Videos.SingleAsync(x => x.VideoId == request.Video.VideoId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Video = video.ToDto()
                };
            }

        }
    }
}
