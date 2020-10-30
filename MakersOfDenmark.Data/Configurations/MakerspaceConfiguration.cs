using MakersOfDenmark.Core.Models.Makerspaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class MakerspaceConfiguration : IEntityTypeConfiguration<Makerspace>
    {
        public void Configure(EntityTypeBuilder<Makerspace> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            //TODO: Add configuration for further constraints
            builder.Property(m => m.Name).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Access_Type).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(1000);
            builder.Property(m => m.OwnerId).IsRequired();
            builder.Property(m => m.CVR).HasMaxLength(8);

            builder
                .HasOne(mb => mb.Address)
                .WithMany(ad => ad.Makerspaces)
                .HasForeignKey(mb => mb.AddressId);
            
            builder
                .ToTable("Makerspaces");
            
            
        }
    }
}