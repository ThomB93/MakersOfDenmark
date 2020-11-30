using System;
using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.Events;

namespace MakersOfDenmark.Core.Models.Makerspaces
{
    public class Makerspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space_Type { get; set; }
        public string Access_Type { get; set; }
        public string CVR { get; set; }
        public string Logo_Url { get; set; }
        public string Description { get; set; }
        public string X_Coords { get; set; }
        public string Y_Coords { get; set; }

        public User Owner { get; set; }
        public Guid OwnerId { get; set; }

        public IList<MakerspaceBadge> MakerspaceBadges { get; set; }
        public IList<MakerspaceUser> MakerspaceUsers { get; set; }

        public IList<Badge> Badges { get; set; }
        public IList<Event> Events { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
        //[ForeignKey("User")] 
        //public Guid UserFK { get; set; }
    }
}