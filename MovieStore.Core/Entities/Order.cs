using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
