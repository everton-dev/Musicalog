using Musicalog.Domain.Entities;
using Musicalog.Domain.Interfaces.Application.Base;
using System.Collections.Generic;

namespace Musicalog.Domain.Interfaces.Application
{
    public interface IAlbumService : IService<Album>
    {
        DefaultResponse<ICollection<Album>> GetAll(string typeOrder);
    }
}