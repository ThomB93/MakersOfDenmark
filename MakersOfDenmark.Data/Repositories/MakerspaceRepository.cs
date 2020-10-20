using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MakersOfDenmark.Data.Repositories
{
    public class MakerspaceRepository : Repository<Makerspace>, IMakerspaceRepository
    {

        private MakersOfDenmarkDbContext MakersOfDenmarkDbContext
        {
            get { return Context as MakersOfDenmarkDbContext; }
        }
        
        public MakerspaceRepository(MakersOfDenmarkDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Makerspace> GetAllMakerspaces()
        {
            return MakersOfDenmarkDbContext.Makerspaces.ToList();
        }

        public void Save(Makerspace makerspace)
        {
            MakersOfDenmarkDbContext.Makerspaces.Add(makerspace);
            MakersOfDenmarkDbContext.SaveChanges();
        }

        public void Update(Makerspace makerspace)
        {
            MakersOfDenmarkDbContext.Makerspaces.Update(makerspace);
            MakersOfDenmarkDbContext.SaveChanges();
        }

        
    }
}