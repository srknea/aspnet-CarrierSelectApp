using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Features.Commands.Order.RemoveOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly private IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveOrderCommandRequest removeOrderCommandRequest)
        {
            RemoveOrderCommandResponse response = await _mediator.Send(removeOrderCommandRequest);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
