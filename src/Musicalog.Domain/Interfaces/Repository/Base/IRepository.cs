using System.Collections.Generic;

namespace Musicalog.Domain.Interfaces.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();
    }
}