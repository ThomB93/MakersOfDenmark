using MakersOfDenmark.Core.Models.Badges;

namespace MakersOfDenmark.Core.Models.Events
{
    public class EventBadge
    {
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}