using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfigurations.CreateCarrierConfigurations
{
    public class CreateCarrierConfigurationsCommandHandler : IRequestHandler<CreateCarrierConfigurationsCommandRequest, CreateCarrierConfigurationsCommandResponse>
    {
        readonly private ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CreateCarrierConfigurationsCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<CreateCarrierConfigurationsCommandResponse> Handle(CreateCarrierConfigurationsCommandRequest request, CancellationToken cancellationToken)
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
