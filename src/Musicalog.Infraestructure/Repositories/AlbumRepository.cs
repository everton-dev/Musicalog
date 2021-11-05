using Microsoft.EntityFrameworkCore;
using Musicalog.Domain.Entities;
using Musicalog.Domain.Interfaces.Repository;
using Musicalog.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Musicalog.Infraestructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationContext _db;

        public AlbumRepository(ApplicationContext db)
        {
            _db = db;
        }

        public int Delete(int id)
        {
            var album = _db.Albums.Find(id);

            _db.Albums.Remove(album);

            return _db.SaveChanges();
        }

        public ICollection<Album> GetAll() =>
            (from p in _db.Albums.AsNoTracking().Include(p => p.Type) select p).ToList();

        public ICollection<Album> GetAllOrderByArtistName() =>
            (from p in _db.Albums.AsNoTracking().Include(p => p.Type) select p).OrderBy(a => a.ArtistName).ToList();

        public ICollection<Album> GetAllOrderByTitle() =>
            (from p in _db.Albums.AsNoTracking().Include(p => p.Type) select p).OrderBy(a => a.Title).ToList();

        public Album GetById(int id) =>
            _db.Albums.AsNoTracking()
                .Include(p => p.Type)
            .FirstOrDefault(p => p.Id.Equals(id));

        public int Insert(Album entity)
        {
            _db.Albums.Add(entity);
            return _db.SaveChanges();
        }

        public int Update(Album entity)
        {
            var album = _db.Albums.Find(entity.Id);

            album.Title = entity.Title;
            album.ArtistName = entity.ArtistName;
            album.TypeAlbumId = entity.TypeAlbumId;
            album.Stock = entity.Stock;
            album.Type = null;

            return _db.SaveChanges();
        }
    }
}