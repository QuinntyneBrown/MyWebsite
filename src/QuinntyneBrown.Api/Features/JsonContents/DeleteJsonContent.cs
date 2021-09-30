using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using QuinntyneBrown.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QuinntyneBrown.Api.Features
{
    public class DeleteJsonContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.JsonContent).NotNull();
                RuleFor(request => request.JsonContent).SetValidator(new JsonContentValidator());
            }
        }

        public class Request : IRequest<Response> { 
            public JsonContentDto JsonContent { get; set; }        
        }

        public class Response: ResponseBase
        {
            public JsonContentDto JsonContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var jsonContent = await _context.JsonContents.SingleAsync(x => x.JsonContentId == request.JsonContent.JsonContentId);

                _context.JsonContents.Remove(jsonContent);

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 
                    JsonContent = jsonContent.ToDto()
                };
            }
        }
    }
}
