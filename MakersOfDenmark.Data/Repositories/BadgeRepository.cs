using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Repositories;

namespace MakersOfDenmark.Data.Repositories
{
    public class BadgeRepository : Repository<Badge>, IBadgeRepository
    {
        private MakersOfDenmarkDbContext MakersOfDenmarkDbContext
        {
            get { return Context as MakersOfDenmarkDbContext; }
        }
        
        public BadgeRepository(MakersOfDenmarkDbContext context) : base(context)
        {
            
        }
    }
}