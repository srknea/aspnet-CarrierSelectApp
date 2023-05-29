using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        readonly private ICarrierReadRepository _carrierReadRepository;
        readonly private ICarrierWriteRepository _carrierWriteRepository;
        public CarrierController(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
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

    }
}

//OrderDate = DateTime.Now