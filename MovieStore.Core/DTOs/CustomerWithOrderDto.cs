using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.DTOs
{
    public class CustomerWithOrderDto:CustomerDto
    {
        public List<OrderDto> Orders { get; set; }
    }
}
