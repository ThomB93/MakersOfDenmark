using System;
using System.Collections.Generic;
using System.Text;
using MakersOfDenmark.Core.Models.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class EventBadgeConfiguration : IEntityTypeConfiguration<EventBadge>
    {
        public void Configure(EntityTypeBuilder<EventBadge> builder)
        {
            builder.HasKey(eb => new { eb.BadgeId, eb.EventId });

            builder
                .HasOne(mb => mb.Badge)
                .WithMany(b => b.EventBadges)
                .HasForeignKey(mb => mb.BadgeId);

            builder
                .HasOne(mb => mb.Event)
                .WithMany(m => m.EventBadges)
                .HasForeignKey(mb => mb.EventId);
        }
    }
}
