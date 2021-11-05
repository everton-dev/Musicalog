using System.Collections.Generic;

namespace Musicalog.Domain.Entities
{
    public class TypeAlbum
    {
        public TypeAlbum()
        {
        }

        public TypeAlbum(short id, string description, List<Album> albums)
        {
            Id = id;
            Description = description;
            Albums = albums ?? new List<Album>();
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}