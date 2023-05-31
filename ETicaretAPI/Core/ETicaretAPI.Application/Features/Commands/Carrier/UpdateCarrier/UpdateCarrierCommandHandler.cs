using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, UpdateCarrierCommandResponse>
    {
        readonly private ICarrierReadRepository _carrierReadRepository;
        readonly private ICarrierWriteRepository _carrierWriteRepository;

        public UpdateCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<UpdateCarrierCommandResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Carrier carrier = await _carrierReadRepository.GetByIdAsync(Convert.ToString(request.Id));
            /*
            if (carrier == null)
            {
                throw new Exception("Carrier not found");
            }
            */
            carrier.CarrierName = request.CarrierName;
            carrier.CarrierIsActive = request.CarrierIsActive;
            carrier.CarrierPlusDesiCost = request.CarrierPlusDesiCost;
            await _carrierWriteRepository.SaveAsync();
            return new();
        }
    }
}

/*
public int Id { get; set; }
public string CarrierName { get; set; }
public bool CarrierIsActive { get; set; }
public int CarrierPlusDesiCost { get; set; }
*/