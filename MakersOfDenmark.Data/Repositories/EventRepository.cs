using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MakersOfDenmark.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DbContext context) : base(context)
        {
        }

        private MakersOfDenmarkDbContext MakersOfDenmarkDbContext => Context as MakersOfDenmarkDbContext;
    }
}