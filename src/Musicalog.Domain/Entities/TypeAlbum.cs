using System.Collections.Generic;

namespace Musicalog.Domain.Entities
{
    public class TypeAlbum
    {
        public TypeAlbum()
        {
        }

        public TypeAlbum(short id, string description)
        {
            Id = id;
            Description = description;
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}