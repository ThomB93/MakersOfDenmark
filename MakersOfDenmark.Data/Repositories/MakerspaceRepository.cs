﻿using System;
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
        
        public async Task<IEnumerable<Makerspace>> GetAllMakerspacesWithOwner()
        {
            return await MakersOfDenmarkDbContext.Makerspaces
                .Include(m => m.User)
                .ToListAsync();
        }
        public async Task<Makerspace> GetMakerspaceWithOwnerById(int id)
        {
            return await MakersOfDenmarkDbContext.Makerspaces
                .Include(m => m.User)
                .SingleOrDefaultAsync(m => m.Id == id);
        }
        
        
        //Standard repository functionality does not need to be overwritten

        /*public IEnumerable<Makerspace> GetAllMakerspaces()
        {
            return MakersOfDenmarkDbContext.Makerspaces.ToList();
        }*/

        /*public void Save(Makerspace makerspace)
        {
            MakersOfDenmarkDbContext.Makerspaces.Add(makerspace);
            MakersOfDenmarkDbContext.SaveChanges();
        }*/

        /*public void Update(Makerspace makerspace)
        {
            MakersOfDenmarkDbContext.Makerspaces.Update(makerspace);
            MakersOfDenmarkDbContext.SaveChanges();
        }*/

        /*public void Delete(int id)
        {
            var makerspace = MakersOfDenmarkDbContext.Makerspaces.Find(id);
            MakersOfDenmarkDbContext.Remove(makerspace);
            MakersOfDenmarkDbContext.SaveChanges();
        }*/

        /*public Makerspace GetMakerspaceById(int id)
        {
            return MakersOfDenmarkDbContext.Makerspaces.FirstOrDefault(u => u.Id == id);
        }*/

        /*public Makerspace FindById(int id)
        {
            return MakersOfDenmarkDbContext.Makerspaces.Find(id);
        }*/

        
    }
}