using ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
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
        readonly private ICarrierReadRepository _carrierReadRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierReadRepository carrierReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            int siparisDesi = request.OrderDesi;
            
            //Kargo firmalarının desi aralıklarını ve fiyatlarını içeren veri kaynağından bilgileri alma
            List<Domain.Entities.CarrierConfiguration> carrierConfigurations = await _carrierConfigurationReadRepository.GetAll().ToListAsync();
            List<Domain.Entities.Carrier> carriers = await _carrierReadRepository.GetAll().ToListAsync();

            bool foundMatchingConfiguration = false;
            decimal minKargoUcreti = decimal.MaxValue;
            int selectedCarrierId = 0;

            //Siparişin desi değerinin hangi kargo firmasının desi aralığına girdiğini bulma
            foreach (Domain.Entities.CarrierConfiguration configuration in carrierConfigurations)
            {
                if (siparisDesi >= configuration.CarrierMinDesi && siparisDesi <= configuration.CarrierMaxDesi)
                {
                    foundMatchingConfiguration = true;

                    //Select the carrier with the lowest cost
                    if (configuration.CarrierCost < minKargoUcreti)
                    {
                        minKargoUcreti = configuration.CarrierCost;
                        selectedCarrierId = configuration.CarrierId;
                    }
                }
            }

            if (foundMatchingConfiguration)
            {
                await _orderWriteRepository.AddAsync(new()
                {
                    OrderDesi = request.OrderDesi,
                    OrderDate = DateTime.Now,
                    OrderCarrierCost = minKargoUcreti,
                    CarrierId = selectedCarrierId
                });

                await _orderWriteRepository.SaveAsync();

                return new();
            }

            decimal kargoUcreti = 0;
            int plusDesiCost = 0;
            int carrierId = 0;

            // Siparişin desi değerinin hiçbir kargo firmasının desi aralığına girmemesi durumu
            foreach (Domain.Entities.CarrierConfiguration configuration in carrierConfigurations)
            {
                decimal enYakinDesiFarki = decimal.MaxValue; // En yakın desi farkını takip etmek için bir başlangıç değeri atama

                // Siparişin desi değeri ile kargo yapılandırmasının en yakın desi değeri arasındaki farkı hesaplama
                decimal desiFarki = Math.Abs(siparisDesi - configuration.CarrierMaxDesi);

                if (desiFarki < enYakinDesiFarki)
                {
                    enYakinDesiFarki = desiFarki;

                    foreach (Domain.Entities.Carrier carrier in carriers)
                    {
                        if (configuration.CarrierId == carrier.Id)
                        {
                            plusDesiCost = carrier.CarrierPlusDesiCost;
                            carrierId = carrier.Id;
                        }
                    }

                    // Kargo ücretini hesaplama
                    kargoUcreti = configuration.CarrierCost + (plusDesiCost * enYakinDesiFarki);
                }
            }

            await _orderWriteRepository.AddAsync(new()
            {
                OrderDesi = request.OrderDesi,
                OrderDate = DateTime.Now,
                OrderCarrierCost = kargoUcreti,
                CarrierId = carrierId
            });
            await _orderWriteRepository.SaveAsync();

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