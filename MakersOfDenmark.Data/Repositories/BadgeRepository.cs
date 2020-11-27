using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Repositories;

namespace MakersOfDenmark.Data.Repositories
{
    public class BadgeRepository : Repository<Badge>, IBadgeRepository
    {
        public BadgeRepository(MakersOfDenmarkDbContext context) : base(context)
        {
        }

        private MakersOfDenmarkDbContext MakersOfDenmarkDbContext => Context as MakersOfDenmarkDbContext;
    }
}