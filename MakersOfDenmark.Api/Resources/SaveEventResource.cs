using System;
using System.Collections.Generic;

namespace MakersOfDenmark.Api.Resources
{
    public class SaveEventResource
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime Deadline { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MakerspaceId { get; set; }
        public IList<BadgeResource>? EventBadges { get; set; }
    }
}