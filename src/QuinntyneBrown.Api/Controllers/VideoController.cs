using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{videoId}", Name = "GetVideoByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetVideoById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetVideoById.Response>> GetById([FromRoute] GetVideoById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Video == null)
            {
                return new NotFoundObjectResult(request.VideoId);
            }

            return response;
        }

        [HttpGet(Name = "GetVideosRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetVideos.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetVideos.Response>> Get()
            => await _mediator.Send(new GetVideos.Request());

        [HttpPost(Name = "CreateVideoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateVideo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateVideo.Response>> Create([FromBody] CreateVideo.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetVideosPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetVideosPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetVideosPage.Response>> Page([FromRoute] GetVideosPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateVideoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateVideo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateVideo.Response>> Update([FromBody] UpdateVideo.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{videoId}", Name = "RemoveVideoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveVideo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveVideo.Response>> Remove([FromRoute] RemoveVideo.Request request)
            => await _mediator.Send(request);

    }
}
