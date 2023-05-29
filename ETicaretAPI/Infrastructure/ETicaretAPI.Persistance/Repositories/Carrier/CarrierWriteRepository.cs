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
    public class CarrierWriteRepository : WriteRepository<Carrier>, ICarrierWriteRepository
    {
        public CarrierWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
