using System;
using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;

namespace MakersOfDenmark.Api.Resources
{
    public class MakerspaceResource
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
        public UserResource Owner { get; set; }
        public AddressResource Address { get; set; }
        public IList<BadgeResource> MakerspaceBadges { get; set; }
        public IList<UserResource> MakerspaceUsers { get; set; }
    }
}