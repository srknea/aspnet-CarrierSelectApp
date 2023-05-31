using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandHandler : IRequestHandler<RemoveCarrierConfigurationCommandRequest, RemoveCarrierConfigurationCommandResponse>
    {
        readonly private ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public RemoveCarrierConfigurationCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<RemoveCarrierConfigurationCommandResponse> Handle(RemoveCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(request.Id);
            await _carrierConfigurationWriteRepository.SaveAsync();
            return new();
        }
    }
}
