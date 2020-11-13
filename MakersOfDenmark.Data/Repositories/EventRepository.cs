using System;
using System.Collections.Generic;
using System.Text;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MakersOfDenmark.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private MakersOfDenmarkDbContext MakersOfDenmarkDbContext
        {
            get { return Context as MakersOfDenmarkDbContext; }
        }
        public EventRepository(DbContext context) : base(context)
        {
        }
    }
}
