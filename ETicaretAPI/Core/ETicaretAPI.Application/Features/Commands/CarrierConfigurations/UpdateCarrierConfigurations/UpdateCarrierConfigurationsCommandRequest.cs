using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfigurations.UpdateCarrierConfigurations
{
    public class UpdateCarrierConfigurationsCommandRequest : IRequest<UpdateCarrierConfigurationsCommandResponse>
    {
        public int Id { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}
