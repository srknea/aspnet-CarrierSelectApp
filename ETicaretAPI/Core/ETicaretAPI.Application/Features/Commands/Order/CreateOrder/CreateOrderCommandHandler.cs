using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly private IOrderWriteRepository _orderWriteRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                OrderDesi = request.OrderDesi,
                OrderDate = DateTime.Now,
                OrderCarrierCost = request.OrderCarrierCost,
                CarrierId = request.CarrierId
            });

            await _orderWriteRepository.SaveAsync();

            return new();
        }
    }
}