using ETicaretAPI.Application.Features.Queries.Carrier.GetByIdCarrier;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        readonly private IOrderReadRepository _orderReadRepository;

        public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Order order = await _orderReadRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            return new()
            {
                OrderDesi = order.OrderDesi,
                OrderDate = order.OrderDate,
                OrderCarrierCost = order.OrderCarrierCost,
                CarrierId = order.CarrierId
            };
        }
    }
}