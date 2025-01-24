using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class InventoryModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public int InRepair { get; set; }
        public decimal Price { get; set; }
       
    }
}
