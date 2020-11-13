using System;
using System.Collections.Generic;
using System.Text;
using MakersOfDenmark.Core.Models.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
    {
        public void Configure(EntityTypeBuilder<EventRegistration> builder)
        {
            builder.HasKey(eb => new { eb.UserId, eb.EventId });

            builder
                .HasOne(mb => mb.User)
                .WithMany(b => b.EventsRegisteredFor)
                .HasForeignKey(mb => mb.UserId);

            builder
                .HasOne(mb => mb.Event)
                .WithMany(m => m.RegisteredUsers)
                .HasForeignKey(mb => mb.EventId);
        }
    }
}
