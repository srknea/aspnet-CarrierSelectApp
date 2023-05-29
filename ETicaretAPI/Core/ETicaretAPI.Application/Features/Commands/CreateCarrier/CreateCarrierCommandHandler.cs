using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        readonly private ICarrierWriteRepository _carrierWriteRepository;

        public CreateCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierWriteRepository.AddAsync(new()
            {
                CarrierName = request.CarrierName,
                CarrierIsActive = request.CarrierIsActive,
                CarrierPlusDesiCost = request.CarrierPlusDesiCost
            });

            await _carrierWriteRepository.SaveAsync();

            return new();
        }
    }
}
