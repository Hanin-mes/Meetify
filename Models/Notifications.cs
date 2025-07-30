using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Notifications
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public Users? User { get; set; }
        public string? Title { get; set; }

        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
