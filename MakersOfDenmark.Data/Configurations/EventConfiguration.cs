using System;
using System.Collections.Generic;
using System.Text;
using MakersOfDenmark.Core.Models.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasKey(a => a.Id);
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Description)
                .HasMaxLength(280);

            builder.HasOne(a => a.MakerspaceHost)
                .WithMany(a => a.Events)
                .HasForeignKey(a => a.MakerspaceId);
        }
    }
}
