using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{profileId}", Name = "GetProfileByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileById.Response>> GetById([FromRoute] GetProfileById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Profile == null)
            {
                return new NotFoundObjectResult(request.ProfileId);
            }

            return response;
        }

        [HttpGet("name/{fullname}", Name = "GetProfileByNameRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileByName.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileByName.Response>> GetByName([FromRoute] GetProfileByName.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Profile == null)
            {
                return new NotFoundObjectResult(request.Fullname);
            }

            return response;
        }

        [HttpGet(Name = "GetProfilesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfiles.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfiles.Response>> Get()
            => await _mediator.Send(new GetProfiles.Request());

        [HttpPost(Name = "CreateProfileRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProfile.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProfile.Response>> Create([FromBody] CreateProfile.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetProfilesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfilesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfilesPage.Response>> Page([FromRoute] GetProfilesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateProfileRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProfile.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProfile.Response>> Update([FromBody] UpdateProfile.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{profileId}", Name = "RemoveProfileRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProfile.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProfile.Response>> Remove([FromRoute] RemoveProfile.Request request)
            => await _mediator.Send(request);

    }
}
