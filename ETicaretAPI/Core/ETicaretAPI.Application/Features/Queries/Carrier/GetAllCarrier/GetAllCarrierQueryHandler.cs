using ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryHandler : IRequestHandler<GetAllCarrierQueryRequest, GetAllCarrierQueryResponse>
    {
        readonly private ICarrierReadRepository _carrierReadRepository;

        public GetAllCarrierQueryHandler(ICarrierReadRepository carrierReadRepository)
        {
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<GetAllCarrierQueryResponse> Handle(GetAllCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            var carriers = await _carrierReadRepository.GetAll()
                                .Select(c => new
                                {
                                    c.Id,
                                    c.CarrierName,
                                    c.CarrierIsActive,
                                    c.CarrierPlusDesiCost,
                                })
                                .ToListAsync();
            return new()
            {
                Carriers = carriers
            };
        }
    }
}
