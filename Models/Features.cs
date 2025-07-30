using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Features
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public ICollection<RoomFeatures>? RoomFeatures { get; set; }
    }
}
