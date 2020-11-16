using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Data.Repositories;

namespace MakersOfDenmark.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MakersOfDenmarkDbContext _context;

        public UnitOfWork(MakersOfDenmarkDbContext context)
        {
            _context = context;
            Makerspaces = new MakerspaceRepository(context);
            Badges = new BadgeRepository(context);
            Events = new EventRepository(context);
            Users = new UserRepository(context);
        }

        private MakerspaceRepository Makerspaces { get; }
        private BadgeRepository Badges { get; }
        private EventRepository Events { get; }
        private UserRepository Users { get; }

        IMakerspaceRepository IUnitOfWork.Makerspaces => Makerspaces;

        IBadgeRepository IUnitOfWork.Badges => Badges;

        IEventRepository IUnitOfWork.Events => Events;

        IUserRepository IUnitOfWork.Users => Users;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}