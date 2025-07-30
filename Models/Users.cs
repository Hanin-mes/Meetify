using System;
using System.Collections.Generic;

namespace Meetify.Models
{
    public class Users
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; } // Admin, Employee, Guest
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Meetings>? OrganizedMeetings { get; set; }
        public ICollection<Attendees>? AttendedMeetings { get; set; }
        public ICollection<MeetingTasks>? AssignedMeetinTasks { get; set; }
        public ICollection<Notifications>? Notifications { get; set; }
        public ICollection<Logs>? Logs { get; set; }
    }
}