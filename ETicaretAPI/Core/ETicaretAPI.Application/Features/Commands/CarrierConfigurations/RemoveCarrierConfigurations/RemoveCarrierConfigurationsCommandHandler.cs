using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfigurations.RemoveCarrierConfigurations
{
    public class RemoveCarrierConfigurationsCommandHandler : IRequestHandler<RemoveCarrierConfigurationsCommandRequest, RemoveCarrierConfigurationsCommandResponse>
    {
        readonly private ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public RemoveCarrierConfigurationsCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<RemoveCarrierConfigurationsCommandResponse> Handle(RemoveCarrierConfigurationsCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(request.Id);
            await _carrierConfigurationWriteRepository.SaveAsync();
            return new();
        }
    }
}
