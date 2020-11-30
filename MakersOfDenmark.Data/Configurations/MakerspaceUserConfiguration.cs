using MakersOfDenmark.Core.Models.Makerspaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakersOfDenmark.Data.Configurations
{
    public class MakerspaceUserConfiguration : IEntityTypeConfiguration<MakerspaceUser>
    {
        public void Configure(EntityTypeBuilder<MakerspaceUser> builder)
        {
            builder.HasKey(mb => new {mb.UserId, mb.MakerspaceId});

            builder
                .HasOne(mb => mb.User)
                .WithMany(b => b.MakerspacesJoined)
                .HasForeignKey(mb => mb.UserId);

            builder
                .HasOne(mb => mb.Makerspaces)
                .WithMany(m => m.MakerspaceUsers)
                .HasForeignKey(mb => mb.MakerspaceId);
        }
    }
}