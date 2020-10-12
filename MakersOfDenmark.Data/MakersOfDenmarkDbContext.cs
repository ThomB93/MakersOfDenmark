using System;
using MakersOfDenmark.Core.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MakersOfDenmark.Data
{
    public class MakersOfDenmarkDbContext : IdentityDbContext<User, Role, Guid>
    {
        public MakersOfDenmarkDbContext(DbContextOptions<MakersOfDenmarkDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}