using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController
    {
        private readonly IMediator _mediator;

        public BlogPostController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{blogPostId}", Name = "GetBlogPostByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBlogPostById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBlogPostById.Response>> GetById([FromRoute] GetBlogPostById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.BlogPost == null)
            {
                return new NotFoundObjectResult(request.BlogPostId);
            }

            return response;
        }

        [HttpGet(Name = "GetBlogPostsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBlogPosts.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBlogPosts.Response>> Get()
            => await _mediator.Send(new GetBlogPosts.Request());

        [HttpPost(Name = "CreateBlogPostRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBlogPost.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBlogPost.Response>> Create([FromBody] CreateBlogPost.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetBlogPostsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBlogPostsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBlogPostsPage.Response>> Page([FromRoute] GetBlogPostsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateBlogPostRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBlogPost.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBlogPost.Response>> Update([FromBody] UpdateBlogPost.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{blogPostId}", Name = "RemoveBlogPostRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBlogPost.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBlogPost.Response>> Remove([FromRoute] RemoveBlogPost.Request request)
            => await _mediator.Send(request);

    }
}
