using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryResponse
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}
