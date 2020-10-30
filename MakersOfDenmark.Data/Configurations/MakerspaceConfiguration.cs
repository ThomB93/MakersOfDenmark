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
            
            /*builder
                .Property(m => m.Name)
                .IsRequired();*/
            
            builder
                .HasOne(m => m.User)
                .WithMany(u => u.MakerspacesJoined)
                .HasForeignKey(m => m.OwnerId);

            builder
                .HasOne(mb => mb.Address)
                .WithMany(ad => ad.Makerspaces)
                .HasForeignKey(mb => mb.AddressId);
            
            builder
                .ToTable("Makerspaces");
            
            
        }
    }
}