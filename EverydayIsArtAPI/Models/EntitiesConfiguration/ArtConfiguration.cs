using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverydayIsArtAPI.Models
{
    public class ArtConfiguration : IEntityTypeConfiguration<Art>
    {
        public void Configure(EntityTypeBuilder<Art> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("PK_Art");

            builder
                .Property(e => e.ImageUrl)
                .IsRequired();
            builder
                .Property(e => e.SourceUrl)
                .IsRequired();
            builder
                .Property(e => e.SourceUrlText)
                .IsRequired();

            builder
                .ToTable("Arts");
        }
    }
}