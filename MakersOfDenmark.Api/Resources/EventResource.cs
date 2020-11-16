using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakersOfDenmark.Api.Resources
{
    public class EventResource
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime Deadline { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MakerspaceResource MakerspaceHost { get; set; }
        public IList<BadgeResource> EventBadges { get; set; }
        public IList<UserResource> RegisteredUsers { get; set; }
    }
}
