using System;
using MakersOfDenmark.Core.Models;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Models.UserRelations;
using MakersOfDenmark.Data.Configurations;
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

        public DbSet<Makerspace> Makerspaces { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<MakerspaceBadge> MakerspaceBadges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        public DbSet<MakerspaceUser> MakerspaceUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<EventBadge> EventBadges { get; set; }

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
                .ApplyConfiguration(new MakerspaceUserConfiguration());
            builder
                .ApplyConfiguration(new UserBadgeConfiguration());
            builder
                .ApplyConfiguration(new EventConfiguration());
            builder
                .ApplyConfiguration(new EventBadgeConfiguration());
            builder
                .ApplyConfiguration(new EventRegistrationConfiguration());

            base.OnModelCreating(builder);
        }
    }
}