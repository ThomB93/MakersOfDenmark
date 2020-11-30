using MakersOfDenmark.Core.Models.Badges;

namespace MakersOfDenmark.Core.Models.Makerspaces
{
    public class MakerspaceBadge
    {
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }

        public int MakerspaceId { get; set; }
        public Makerspace Makerspaces { get; set; }
    }
}