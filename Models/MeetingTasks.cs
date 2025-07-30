using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class MeetingTasks
    {
        public long Id { get; set; }

        public long MeetingId { get; set; }
        public Meetings? Meeting { get; set; }

        public long AssignedToUserId { get; set; }
        public Users? AssignedToUser { get; set; }

        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
       
        public string? Status { get; set; } // Pending, Completed, Overdue

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }



    }
}
