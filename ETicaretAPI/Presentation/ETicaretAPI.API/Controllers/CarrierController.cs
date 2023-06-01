using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using ETicaretAPI.Application.Features.Commands.Carrier.UpdateCarrier;
using ETicaretAPI.Application.Features.Queries.Carrier.GetAllCarrier;
using ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        readonly private IMediator _mediator;
        public CarrierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierCommandRequest createCarrierCommandRequest)
        {
            CreateCarrierCommandResponse response = await _mediator.Send(createCarrierCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCarrierCommandRequest removeCarrierCommandRequest)
        {
            RemoveCarrierCommandResponse response = await _mediator.Send(removeCarrierCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCarrierCommandRequest updateCarrierCommandRequest)
        {
            UpdateCarrierCommandResponse response = await _mediator.Send(updateCarrierCommandRequest);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCarrierQueryRequest getByIdCarrierQueryRequest)
        {
            GetByIdCarrierQueryResponse response = await _mediator.Send(getByIdCarrierQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllCarrierQueryResponse response = await _mediator.Send(new GetAllCarrierQueryRequest());
            return Ok(response);
        }
    }
}

//OrderDate = DateTime.Now

/*
readonly private ICarrierReadRepository _carrierReadRepository;
readonly private ICarrierWriteRepository _carrierWriteRepository;
*/

/*
[HttpGet]
public async Task Get()
{
    await _carrierWriteRepository.AddRangeAsync(new()
    {
        new() { CarrierName = "Aras", CarrierIsActive = true, CarrierPlusDesiCost = 10},
        new() { CarrierName = "Yurtiçi", CarrierIsActive = false, CarrierPlusDesiCost = 20},
        new() { CarrierName = "UPS", CarrierIsActive = true, CarrierPlusDesiCost = 30},
    });

    await _carrierWriteRepository.SaveAsync();
}

[HttpGet("{id}")]
public async Task<IActionResult> Get(string id)
{
    var product = await _carrierReadRepository.GetByIdAsync(id);
    return Ok(product);
}

[HttpDelete("{Id}")]
public async Task<IActionResult> Delete(string Id)
{
    await _carrierWriteRepository.RemoveAsync(Id);
    await _carrierWriteRepository.SaveAsync();
    return Ok();
}

[HttpGet]
public async Task<IActionResult> GetAllEntities()
{
    var entities = await _carrierReadRepository.GetAll()
                        .Select(c => new
                        {
                            c.Id,
                            c.CarrierName,
                            c.CarrierIsActive,
                            c.CarrierPlusDesiCost,
                        })
                        .ToListAsync();
    return Ok(entities);
}
*/