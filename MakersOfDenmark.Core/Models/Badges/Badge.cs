using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Models.Badges
{
    public class Badge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int IssuerId { get; set; }
        public Makerspace Issuer { get; set; }
        
        public IList<MakerspaceBadge> MakerspaceBadges { get; set; }
    }
}