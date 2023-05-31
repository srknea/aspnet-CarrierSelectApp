using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.UpdateCarrier;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier;
using ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        readonly private IMediator _mediator;
        public CarrierConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierConfigurationCommandRequest createCarrierConfigurationCommandRequest)
        {
            CreateCarrierConfigurationCommandResponse response = await _mediator.Send(createCarrierConfigurationCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCarrierConfigurationCommandRequest removeCarrierConfigurationsCommandRequest)
        {
            RemoveCarrierConfigurationCommandResponse response = await _mediator.Send(removeCarrierConfigurationsCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCarrierConfigurationCommandRequest updateCarrierConfigurationsCommandRequest)
        {
            UpdateCarrierConfigurationCommandResponse response = await _mediator.Send(updateCarrierConfigurationsCommandRequest);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCarrierConfigurationQueryRequest getByIdCarrierConfigurationQueryRequest)
        {
            GetByIdCarrierConfigurationQueryResponse response = await _mediator.Send(getByIdCarrierConfigurationQueryRequest);
            return Ok(response);
        }
    }
}
