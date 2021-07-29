using System.Net;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuinntyneBrown.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DigitalAssetController
    {
        private readonly IMediator _mediator;

        public DigitalAssetController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("page/{pageSize}/{index}", Name = "GetDigitalAssetsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDigitalAssetsPage.Response>> Page([FromRoute] GetDigitalAssetsPage.Request request)
            => await _mediator.Send(request);

        [HttpGet("{digitalAssetId}", Name = "GetDigitalAssetByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetDigitalAssetById.Response>> GetById([FromRoute] GetDigitalAssetById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
            {
                return new NotFoundObjectResult(request.DigitalAssetId);
            }

            return response;
        }

        [HttpGet("range")]
        public async Task<ActionResult<GetDigitalAssetsByIds.Response>> GetByIds([FromQuery] GetDigitalAssetsByIds.Request request)
            => await _mediator.Send(request);

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAsset.Response>> Save()
            => await _mediator.Send(new UploadDigitalAsset.Request());

        [AllowAnonymous]
        [HttpGet("serve/{digitalAssetId}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Serve([FromRoute] GetDigitalAssetById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
                return new NotFoundObjectResult(null);

            return new FileContentResult(response.DigitalAsset.Bytes, response.DigitalAsset.ContentType);
        }

        [AllowAnonymous]
        [HttpGet("serve/name/{filename}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ServeByName([FromRoute] GetDigitalAssetByFilename.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
                return new NotFoundObjectResult(null);

            return new FileContentResult(response.DigitalAsset.Bytes, response.DigitalAsset.ContentType);
        }

        [HttpDelete("{digitalAssetId}", Name = "RemoveDigitalAssetRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDigitalAsset.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDigitalAsset.Response>> Remove([FromRoute] RemoveDigitalAsset.Request request)
            => await _mediator.Send(request);
    }
}
