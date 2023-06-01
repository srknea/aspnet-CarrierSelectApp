using ETicaretAPI.Application.Features.Queries.Carrier.GetAllCarrier;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryHandler : IRequestHandler<GetAllCarrierConfigurationQueryRequest, GetAllCarrierConfigurationQueryResponse>
    {
        readonly private ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        public GetAllCarrierConfigurationQueryHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public async Task<GetAllCarrierConfigurationQueryResponse> Handle(GetAllCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {

            var carrierConfigurations = await _carrierConfigurationReadRepository.GetAll()
                                .Select(c => new
                                {
                                    c.Id,
                                    c.CarrierMaxDesi,
                                    c.CarrierMinDesi,
                                    c.CarrierCost,
                                    c.CarrierId
                                })
                                .ToListAsync();
            return new()
            {
                CarrierConfigurations = carrierConfigurations
            };
        }
    }
}