using System.Linq;                                     // <-- needed for SelectMany
using Meetify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;                   // <-- NEW
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // <-- NEW

namespace Meetify.Data
{
    // Switch to IdentityDbContext so Identity tables (AspNetUsers, AspNetRoles, …) live in the same DB
    public class MeetifyContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public MeetifyContext(DbContextOptions<MeetifyContext> options)
            : base(options)
        {
        }

        // Your domain tables (unchanged)
        public DbSet<Users> Users { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<RoomFeatures> RoomFeatures { get; set; }
        public DbSet<Meetings> Meetings { get; set; }
        public DbSet<Attendees> Attendees { get; set; }
        public DbSet<MeetingTasks> MeetingTasks { get; set; }
        public DbSet<Attachments> Attachments { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Logs> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IMPORTANT: configure Identity first
            base.OnModelCreating(modelBuilder);

            // Set all foreign keys to Restrict delete behavior
            // (affects all entities, including Identity tables)
            foreach (var fk in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Fluent API relationships (your original mappings)
            modelBuilder.Entity<RoomFeatures>()
                .HasOne(rf => rf.Room)
                .WithMany(r => r.RoomFeatures)
                .HasForeignKey(rf => rf.RoomId);

            modelBuilder.Entity<RoomFeatures>()
                .HasOne(rf => rf.Feature)
                .WithMany(f => f.RoomFeatures)
                .HasForeignKey(rf => rf.FeatureId);

            modelBuilder.Entity<Meetings>()
                .HasOne(m => m.Room)
                .WithMany(r => r.Meetings)
                .HasForeignKey(m => m.RoomId);

            modelBuilder.Entity<Meetings>()
                .HasOne(m => m.Organizer)
                .WithMany(u => u.OrganizedMeetings)
                .HasForeignKey(m => m.OrganizerId);

            modelBuilder.Entity<Attendees>()
                .HasOne(a => a.Meeting)
                .WithMany(m => m.Attendees)
                .HasForeignKey(a => a.MeetingId);

            modelBuilder.Entity<Attendees>()
                .HasOne(a => a.User)
                .WithMany(u => u.AttendedMeetings)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<MeetingTasks>()
                .HasOne(mt => mt.Meeting)
                .WithMany(m => m.MeetingTasks)
                .HasForeignKey(mt => mt.MeetingId);

            modelBuilder.Entity<MeetingTasks>()
                .HasOne(mt => mt.AssignedToUser)
                .WithMany(u => u.AssignedMeetinTasks)
                .HasForeignKey(mt => mt.AssignedToUserId);

            modelBuilder.Entity<Notifications>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Attachments>()
                .HasOne(a => a.Meeting)
                .WithMany(m => m.Attachments)
                .HasForeignKey(a => a.MeetingId);

            modelBuilder.Entity<Logs>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logs)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Locations>()
                .HasMany(l => l.Rooms)
                .WithOne(r => r.Location)
                .HasForeignKey(r => r.LocationId);
        }
    }
}
