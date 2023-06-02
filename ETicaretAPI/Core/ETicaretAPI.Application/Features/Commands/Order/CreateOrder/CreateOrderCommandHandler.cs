using ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        readonly private ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly private IMediator _mediator;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, IMediator mediator)
        {
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _mediator = mediator;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            int siparisDesi = request.OrderDesi;

            //Kargo firmalarının desi aralıklarını ve fiyatlarını içeren veri kaynağından bilgileri alma
            List<Domain.Entities.CarrierConfiguration> carrierConfigurations = await _carrierConfigurationReadRepository.GetAll().ToListAsync();

            foreach (Domain.Entities.CarrierConfiguration configuration in carrierConfigurations)
            {
                if (siparisDesi >= configuration.CarrierMinDesi && siparisDesi <= configuration.CarrierMaxDesi)
                {
                    // Siparişin kargo ücretini belirleme
                    decimal kargoUcreti = configuration.CarrierCost;

                    await _orderWriteRepository.AddAsync(new()
                    {
                        OrderDesi = request.OrderDesi,
                        OrderDate = DateTime.Now,
                        OrderCarrierCost = kargoUcreti,
                        CarrierId = configuration.CarrierId
                    });

                    await _orderWriteRepository.SaveAsync();
                }
            }
            return new();
        }
    }
}
/*
await _orderWriteRepository.AddAsync(new()
{
    OrderDesi = request.OrderDesi,
    OrderDate = DateTime.Now,
    OrderCarrierCost = request.OrderCarrierCost,
    CarrierId = request.CarrierId
});

await _orderWriteRepository.SaveAsync();

return new();
*/