using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventory.Application.InventoryAppService.Dtos
{
    public class OrderDto
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public string OrderStatus { get; set; }

    }
}
