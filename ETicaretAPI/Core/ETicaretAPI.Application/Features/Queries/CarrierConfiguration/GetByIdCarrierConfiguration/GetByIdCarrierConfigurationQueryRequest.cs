using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration
{
    public class GetByIdCarrierConfigurationQueryRequest : IRequest<GetByIdCarrierConfigurationQueryResponse>
    {
        public string Id { get; set; }
    }
}
