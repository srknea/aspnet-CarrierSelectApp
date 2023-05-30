using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.CreateCarrierConfigurations;
using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.RemoveCarrierConfigurations;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        readonly private IMediator _mediator;
        public CarrierConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierConfigurationsCommandRequest createCarrierConfigurationCommandRequest)
        {
            CreateCarrierConfigurationsCommandResponse response = await _mediator.Send(createCarrierConfigurationCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCarrierConfigurationsCommandRequest removeCarrierConfigurationsCommandRequest)
        {
            RemoveCarrierConfigurationsCommandResponse response = await _mediator.Send(removeCarrierConfigurationsCommandRequest);
            return Ok();
        }
    }
}
