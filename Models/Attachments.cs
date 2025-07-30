using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Attachments
    {
        public long Id { get; set; }

        public long MeetingId { get; set; }
        public Meetings? Meeting { get; set; }

        public string? FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
