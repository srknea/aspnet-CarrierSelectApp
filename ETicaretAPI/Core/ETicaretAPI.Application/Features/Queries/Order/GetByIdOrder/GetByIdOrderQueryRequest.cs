using ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
    {
        public string Id { get; set; }
    }
}
