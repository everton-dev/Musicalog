namespace Musicalog.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public short TypeAlbumId { get; set; }
        public TypeAlbum Type { get; set; }
        public int Stock { get; set; }
    }
}