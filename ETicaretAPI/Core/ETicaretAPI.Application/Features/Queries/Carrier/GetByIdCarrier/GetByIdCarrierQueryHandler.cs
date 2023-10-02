using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryHandler : IRequestHandler<GetByIdCarrierQueryRequest, GetByIdCarrierQueryResponse>
    {
        readonly private ICarrierReadRepository _carrierReadRepository;

        public GetByIdCarrierQueryHandler(ICarrierReadRepository carrierReadRepository)
        {
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<GetByIdCarrierQueryResponse> Handle(GetByIdCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Carrier carrier = await _carrierReadRepository.GetByIdAsync(request.Id);
            if (carrier == null)
            {
                throw new NotFoundException($"Carrier with Id '{request.Id}' not found");
            }
            return new()
            {
                CarrierName = carrier.CarrierName,
                CarrierIsActive = carrier.CarrierIsActive,
                CarrierPlusDesiCost = carrier.CarrierPlusDesiCost
                //Use -> AutoMapper
            };
        }
    }
}