using System;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;

namespace MakersOfDenmark.Core.Models.UserRelations
{
    public class UserBadge
    {
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}