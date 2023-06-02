using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration
{
    public class GetByIdCarrierConfigurationQueryResponse
    {
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}