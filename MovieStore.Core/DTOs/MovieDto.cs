using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.DTOs
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public string MovieGenre { get; set; }
        public decimal Price { get; set; }
    }
}
