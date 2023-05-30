using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandHandler : IRequestHandler<RemoveCarrierCommandRequest, RemoveCarrierCommandResponse>
    {   
        readonly ICarrierWriteRepository _carrierWriteRepository;

        public RemoveCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<RemoveCarrierCommandResponse> Handle(RemoveCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierWriteRepository.RemoveAsync(request.Id);
            await _carrierWriteRepository.SaveAsync();
            return new();
        }
    }
}
