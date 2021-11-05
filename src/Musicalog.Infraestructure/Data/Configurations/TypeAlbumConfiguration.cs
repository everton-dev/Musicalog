using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicalog.Domain.Entities;

namespace Musicalog.Infraestructure.Data.Configurations
{
    public class TypeAlbumConfiguration : IEntityTypeConfiguration<TypeAlbum>
    {
        public void Configure(EntityTypeBuilder<TypeAlbum> builder)
        {
            builder.ToTable("TypeAlbum");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("SMALLINT").IsRequired();
            builder.Property(c => c.Description).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}