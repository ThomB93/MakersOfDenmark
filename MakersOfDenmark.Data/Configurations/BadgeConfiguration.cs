using MakersOfDenmark.Core.Models.Badges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
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
            builder.Property(a => a.Image)
                .IsRequired();

            builder.HasOne(a => a.Issuer)
                .WithMany(a => a.Badges)
                .HasForeignKey(a => a.IssuerId);
        }
    }
}