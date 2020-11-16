using System;
using MakersOfDenmark.Core.Models.Auth;

namespace MakersOfDenmark.Core.Models.Events
{
    public class EventRegistration
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        public DateTime DateOfRegistration { get; set; }
        public bool HasAttended { get; set; }
    }
}