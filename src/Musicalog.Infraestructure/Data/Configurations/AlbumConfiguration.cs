using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicalog.Domain.Entities;

namespace Musicalog.Infraestructure.Data.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(c => c.ArtistName).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(c => c.TypeAlbumId).HasColumnType("SMALLINT").IsRequired();
            builder.Property(c => c.Stock).HasColumnType("INT").IsRequired();

            builder.HasOne(c => c.Type)
                .WithMany(c => c.Albums)
                .HasForeignKey(c => c.TypeAlbumId);
        }
    }
}