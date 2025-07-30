using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Logs
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public Users? User { get; set; }

        public string? Action { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
