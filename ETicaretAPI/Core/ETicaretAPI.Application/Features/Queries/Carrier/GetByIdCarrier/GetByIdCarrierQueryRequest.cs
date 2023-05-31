using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryRequest : IRequest<GetByIdCarrierQueryResponse>
    {
        public string Id { get; set; }
    }
}
