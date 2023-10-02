using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration
{
    public class GetByIdCarrierConfigurationQueryHandler : IRequestHandler<GetByIdCarrierConfigurationQueryRequest, GetByIdCarrierConfigurationQueryResponse>
    {
        readonly private ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        public GetByIdCarrierConfigurationQueryHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public async Task<GetByIdCarrierConfigurationQueryResponse> Handle(GetByIdCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.CarrierConfiguration carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(request.Id);
            if (carrierConfiguration == null)
            {
                throw new NotFoundException($"CarrierConfiguration with Id '{request.Id}' not found");
            }
            return new()
            {
                CarrierMaxDesi = carrierConfiguration.CarrierMaxDesi,
                CarrierMinDesi = carrierConfiguration.CarrierMinDesi,
                CarrierCost = carrierConfiguration.CarrierCost,
                CarrierId = carrierConfiguration.CarrierId
            };
        }
    }
}
