using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        readonly private ICarrierReadRepository _carrierReadRepository;
        readonly private ICarrierWriteRepository _carrierWriteRepository;
        readonly private IMediator _mediator;
        public CarrierController(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository, IMediator mediator)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
            _mediator = mediator;
        }


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

        [HttpPost]
        public async Task<IActionResult> Post(CreateCarrierCommandRequest createCarrierCommandRequest)
        {
            CreateCarrierCommandResponse response = await _mediator.Send(createCarrierCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }


    }
}

//OrderDate = DateTime.Now