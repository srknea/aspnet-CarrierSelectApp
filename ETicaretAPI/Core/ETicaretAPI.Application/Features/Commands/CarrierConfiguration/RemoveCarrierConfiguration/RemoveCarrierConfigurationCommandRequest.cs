using ETicaretAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandRequest : IRequest<RemoveCarrierConfigurationCommandResponse>
    {
        public string Id { get; set; }
    }
}
