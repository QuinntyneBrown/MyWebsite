using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{accountId}", Name = "GetAccountByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAccountById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAccountById.Response>> GetById([FromRoute] GetAccountById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Account == null)
            {
                return new NotFoundObjectResult(request.AccountId);
            }

            return response;
        }

        [HttpGet(Name = "GetAccountsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAccounts.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAccounts.Response>> Get()
            => await _mediator.Send(new GetAccounts.Request());

        [HttpPost(Name = "CreateAccountRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateAccount.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateAccount.Response>> Create([FromBody] CreateAccount.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetAccountsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAccountsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAccountsPage.Response>> Page([FromRoute] GetAccountsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateAccountRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateAccount.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateAccount.Response>> Update([FromBody] UpdateAccount.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{accountId}", Name = "RemoveAccountRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveAccount.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveAccount.Response>> Remove([FromRoute] RemoveAccount.Request request)
            => await _mediator.Send(request);

    }
}
