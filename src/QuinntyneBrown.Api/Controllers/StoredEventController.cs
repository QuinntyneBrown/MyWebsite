using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoredEventController
    {
        private readonly IMediator _mediator;

        public StoredEventController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{storedEventId}", Name = "GetStoredEventByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoredEventById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoredEventById.Response>> GetById([FromRoute] GetStoredEventById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.StoredEvent == null)
            {
                return new NotFoundObjectResult(request.StoredEventId);
            }

            return response;
        }

        [HttpGet(Name = "GetStoredEventsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoredEvents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoredEvents.Response>> Get()
            => await _mediator.Send(new GetStoredEvents.Request());

        [HttpPost(Name = "CreateStoredEventRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStoredEvent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStoredEvent.Response>> Create([FromBody] CreateStoredEvent.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetStoredEventsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoredEventsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoredEventsPage.Response>> Page([FromRoute] GetStoredEventsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateStoredEventRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStoredEvent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStoredEvent.Response>> Update([FromBody] UpdateStoredEvent.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{storedEventId}", Name = "RemoveStoredEventRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStoredEvent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStoredEvent.Response>> Remove([FromRoute] RemoveStoredEvent.Request request)
            => await _mediator.Send(request);

    }
}
