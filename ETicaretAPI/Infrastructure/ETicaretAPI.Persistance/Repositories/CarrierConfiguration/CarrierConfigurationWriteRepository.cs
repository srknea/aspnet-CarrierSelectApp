using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories
{
    public class CarrierConfigurationWriteRepository : WriteRepository<CarrierConfiguration>, ICarrierConfigurationWriteRepository
    {
        public CarrierConfigurationWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
