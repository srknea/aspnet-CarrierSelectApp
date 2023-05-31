using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.CreateCarrierConfigurations;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfigurations.UpdateCarrierConfigurations
{
    public class UpdateCarrierConfigurationsCommandHandler : IRequestHandler<UpdateCarrierConfigurationsCommandRequest, UpdateCarrierConfigurationsCommandResponse>
    {
        readonly private ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly private ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public UpdateCarrierConfigurationsCommandHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<UpdateCarrierConfigurationsCommandResponse> Handle(UpdateCarrierConfigurationsCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CarrierConfiguration carrier = await _carrierConfigurationReadRepository.GetByIdAsync(Convert.ToString(request.Id));
            /*
            if (carrier == null)
            {
                throw new Exception("Carrier not found");
            }
            */
            carrier.CarrierMaxDesi = request.CarrierMaxDesi;
            carrier.CarrierMinDesi = request.CarrierMinDesi;
            carrier.CarrierCost = request.CarrierCost;
            carrier.CarrierId = request.CarrierId;
            await _carrierConfigurationWriteRepository.SaveAsync();
            return new();
        }
    }
}