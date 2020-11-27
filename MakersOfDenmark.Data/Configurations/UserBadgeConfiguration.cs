using MakersOfDenmark.Core.Models.UserRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class UserBadgeConfiguration : IEntityTypeConfiguration<UserBadge>
    {
        public void Configure(EntityTypeBuilder<UserBadge> builder)
        {
            builder.HasKey(ub => new {ub.BadgeId, ub.UserId});

            builder
                .HasOne(ub => ub.Badge)
                .WithMany(b => b.UserBadges)
                .HasForeignKey(mb => mb.BadgeId);

            builder
                .HasOne(mb => mb.User)
                .WithMany(m => m.UserBadges)
                .HasForeignKey(mb => mb.UserId);
        }
    }
}