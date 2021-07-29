using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TalkController
    {
        private readonly IMediator _mediator;

        public TalkController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{talkId}", Name = "GetTalkByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTalkById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTalkById.Response>> GetById([FromRoute] GetTalkById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Talk == null)
            {
                return new NotFoundObjectResult(request.TalkId);
            }

            return response;
        }

        [HttpGet(Name = "GetTalksRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTalks.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTalks.Response>> Get()
            => await _mediator.Send(new GetTalks.Request());

        [HttpPost(Name = "CreateTalkRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTalk.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTalk.Response>> Create([FromBody] CreateTalk.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTalksPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTalksPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTalksPage.Response>> Page([FromRoute] GetTalksPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTalkRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTalk.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTalk.Response>> Update([FromBody] UpdateTalk.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{talkId}", Name = "RemoveTalkRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTalk.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTalk.Response>> Remove([FromRoute] RemoveTalk.Request request)
            => await _mediator.Send(request);

    }
}
