using MakersOfDenmark.Core.Models.Makerspaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class MakerspaceBadgeConfiguration : IEntityTypeConfiguration<MakerspaceBadge>
    {
        public void Configure(EntityTypeBuilder<MakerspaceBadge> builder)
        {
            builder.HasKey(mb => new {mb.BadgeId, mb.MakerspaceId});
            
            builder
                .HasOne(mb => mb.Badge)
                .WithMany(b => b.MakerspaceBadges)
                .HasForeignKey(mb => mb.BadgeId);

            builder
                .HasOne(mb => mb.Makerspaces)
                .WithMany(m => m.MakerspaceBadges)
                .HasForeignKey(mb => mb.MakerspaceId);
            
            
        }
    }
}