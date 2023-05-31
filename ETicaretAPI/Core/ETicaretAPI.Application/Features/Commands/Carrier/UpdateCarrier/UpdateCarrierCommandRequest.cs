using ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandRequest : IRequest<UpdateCarrierCommandResponse>
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
    }
}
