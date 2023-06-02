using ETicaretAPI.Application.Features.Queries.Carrier.GetAllCarrier;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        readonly private IOrderReadRepository _orderReadRepository;

        public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderReadRepository.GetAll()
                             .Select(c => new
                             {
                                 c.Id,
                                 c.OrderDesi,
                                 c.OrderDate,
                                 c.CarrierId,
                             })
                             .ToListAsync();
            return new()
            {
                Orders = orders
            };
        }
    }
}