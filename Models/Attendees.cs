using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Attendees
    {
        public long Id { get; set; }
        public long MeetingId { get; set; }
        public Meetings? Meeting { get; set; }

        public long UserId { get; set; }
        public Users? User { get; set; }

        public bool IsPresent { get; set; }
    }
}
