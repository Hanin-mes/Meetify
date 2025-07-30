using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class RoomFeatures
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public Rooms? Room { get; set; }
        public long FeatureId { get; set; }
        public Features? Feature { get; set; }
    }
}
