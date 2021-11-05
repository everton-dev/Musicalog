using Musicalog.Domain.Entities;
using Musicalog.Domain.Interfaces.Application;
using Musicalog.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace Musicalog.Application.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;
        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public DefaultResponse<int> Delete(int id)
        {
            var result = _repository.Delete(id);

            if (result > 0)
                return new DefaultResponse<int>(true, result);
            else
                return new DefaultResponse<int>(false, "Album was not deleted", result);
        }
            
        public DefaultResponse<ICollection<Album>> GetAll()
        {
            var result = _repository.GetAll();

            if (result?.Count > 0)
                return new DefaultResponse<ICollection<Album>>(true, result);
            else
                return new DefaultResponse<ICollection<Album>>(false, "Albums not found", result);
        }

        public DefaultResponse<ICollection<Album>> GetAll(string typeOrder)
        {
            var result = default(ICollection<Album>);

            switch (typeOrder.ToLower())
            {
                case "title": result = _repository.GetAllOrderByTitle();
                    break;
                case "artist":
                    result = _repository.GetAllOrderByArtistName();
                    break;
                case "artistname":
                    result = _repository.GetAllOrderByArtistName();
                    break;
                default:
                    break;
            }

            if (result?.Count > 0)
                return new DefaultResponse<ICollection<Album>>(true, result);
            else
                return new DefaultResponse<ICollection<Album>>(false, "Albums not found", result);
        }

        public DefaultResponse<Album> GetById(int id)
        {
            var result = _repository.GetById(id);

            if (result != null)
                return new DefaultResponse<Album>(true, result);
            else
                return new DefaultResponse<Album>(false, "Album not found", result);
        }

        public DefaultResponse<int> Insert(Album entity)
        {
            var result = _repository.Insert(entity);

            if (result > 0)
                return new DefaultResponse<int>(true, result);
            else
                return new DefaultResponse<int>(false, "Album was not created", result);
        }

        public DefaultResponse<int> Update(Album entity)
        {
            var result = _repository.Update(entity);

            if (result > 0)
                return new DefaultResponse<int>(true, result);
            else
                return new DefaultResponse<int>(false, "Album was not updated", result);
        }
    }
}
