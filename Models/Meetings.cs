using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Meetings
    {
        public long Id { get; set; }

        public long RoomId { get; set; }
        public Rooms? Room { get; set; }

        public long OrganizerId { get; set; }
        public Users? Organizer { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Status { get; set; } // Scheduled, Cancelled, Done

        public string? Title { get; set; }
        public string? MeetingAgenda { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Attendees>? Attendees { get; set; }
        public ICollection<MeetingTasks>? MeetingTasks { get; set; }
        public ICollection<Attachments>? Attachments { get; set; }
        public ICollection<Rooms>? Rooms { get; set; }






    }
}
