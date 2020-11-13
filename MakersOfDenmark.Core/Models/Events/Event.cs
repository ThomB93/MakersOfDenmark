using System;
using System.Collections.Generic;
using System.Text;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Models.Events
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime Deadline { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MakerspaceId { get; set; }
        public Makerspace MakerspaceHost { get; set; }
        public IList<EventBadge> EventBadges { get; set; }
        public IList<EventRegistration> RegisteredUsers { get; set; }
    }
}
