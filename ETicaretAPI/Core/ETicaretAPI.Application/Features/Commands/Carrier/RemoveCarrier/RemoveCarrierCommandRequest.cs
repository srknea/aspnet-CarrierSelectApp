using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandRequest : IRequest<RemoveCarrierCommandResponse>
    {
        public string Id { get; set; }
    }
}
