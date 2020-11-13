using System;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Badges;

namespace MakersOfDenmark.Core.Services
{
    public interface IBadgeService
    {
        Task<Badge> CreateBadge(Badge newBadge);
        Badge AddBadgeToUser(Guid userId, Badge badgeToAdd);
    }
}