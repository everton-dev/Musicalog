using Musicalog.Domain.Entities;
using Musicalog.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace Musicalog.Domain.Interfaces.Repository
{
    public interface IAlbumRepository : IRepository<Album>
    {
        ICollection<Album> GetAllOrderByTitle();
        ICollection<Album> GetAllOrderByArtistName();
    }
}