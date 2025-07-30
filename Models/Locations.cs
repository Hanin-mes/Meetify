using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Locations
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? Building { get; set; }
        public string? Description { get; set; }

        public ICollection<Rooms>? Rooms { get; set; }
    }
}
