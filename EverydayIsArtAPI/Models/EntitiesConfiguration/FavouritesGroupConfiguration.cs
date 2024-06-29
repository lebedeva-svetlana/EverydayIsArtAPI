using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverydayIsArtAPI.Models
{
    public class FavouritesGroupConfiguration : IEntityTypeConfiguration<FavouritesGroup>
    {
        public void Configure(EntityTypeBuilder<FavouritesGroup> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("PK_FavouritesGroup");

            builder
                .Property(e => e.Title)
                .IsRequired();

            builder
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired(true);

            builder
                .ToTable("FavouritesGroups");
        }
    }
}