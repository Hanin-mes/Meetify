using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Rooms
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public long LocationId { get; set; }
        public Locations? Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<RoomFeatures>? RoomFeatures { get; set; }
        public ICollection<Meetings>? Meetings { get; set; }
    }
}
