using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier;
using ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarrierConfigurationController : CustomBaseController
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
            await _mediator.Send(removeCarrierConfigurationsCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarrierConfigurationCommandRequest updateCarrierConfigurationsCommandRequest)
        {
            UpdateCarrierConfigurationCommandResponse response = await _mediator.Send(updateCarrierConfigurationsCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCarrierConfigurationQueryRequest getByIdCarrierConfigurationQueryRequest)
        {
            GetByIdCarrierConfigurationQueryResponse response = await _mediator.Send(getByIdCarrierConfigurationQueryRequest);

            return CreateActionResult(CustomResponseDto<GetByIdCarrierConfigurationQueryResponse>.Success(200, response));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCarrierConfigurationQueryResponse response = await _mediator.Send(new GetAllCarrierConfigurationQueryRequest());

            return CreateActionResult(CustomResponseDto<GetAllCarrierConfigurationQueryResponse>.Success(200, response));
        }
    }
}
