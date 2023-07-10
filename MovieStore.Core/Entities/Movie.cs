using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName{ get; set; }
        public int MovieYear { get; set; }
        public string MovieGenre { get; set; }
        public decimal Price { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
