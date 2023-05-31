using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationCommandResponse>
    {
        readonly private ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CreateCarrierConfigurationCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<CreateCarrierConfigurationCommandResponse> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.AddAsync(new()
            {
                CarrierMaxDesi = request.CarrierMaxDesi,
                CarrierMinDesi = request.CarrierMinDesi,
                CarrierCost = request.CarrierCost,
                CarrierId = request.CarrierId
            });

            await _carrierConfigurationWriteRepository.SaveAsync();

            return new();
        }
    }
}
