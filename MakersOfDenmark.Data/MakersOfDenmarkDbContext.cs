﻿using System;
using MakersOfDenmark.Core.Models;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Models.UserRelations;
using MakersOfDenmark.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data
{
    public class MakersOfDenmarkDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Makerspace> Makerspaces { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<MakerspaceBadge> MakerspaceBadges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        
        public MakersOfDenmarkDbContext(DbContextOptions<MakersOfDenmarkDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //custom configurations
            builder
                .ApplyConfiguration(new MakerspaceConfiguration());
            builder
                .ApplyConfiguration(new BadgeConfiguration());
            builder
                .ApplyConfiguration(new MakerspaceBadgeConfiguration());

            builder
                .ApplyConfiguration(new UserConfiguration());
            
            builder
                .ApplyConfiguration(new UserBadgeConfiguration());
            
            
            base.OnModelCreating(builder);
            
        }
    }

    
}