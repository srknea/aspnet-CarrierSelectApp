using ETicaretAPI.Application.Features.Commands.CarrierConfigurations.CreateCarrierConfigurations;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        readonly private ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly private ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
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