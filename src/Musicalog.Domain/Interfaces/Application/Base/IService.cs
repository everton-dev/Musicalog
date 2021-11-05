using Musicalog.Domain.Entities;
using System.Collections.Generic;

namespace Musicalog.Domain.Interfaces.Application.Base
{
    public interface IService<TEntity> where TEntity : class
    {
        DefaultResponse<int> Insert(TEntity entity);
        DefaultResponse<int> Update(TEntity entity);
        DefaultResponse<int> Delete(int id);
        DefaultResponse<TEntity> GetById(int id);
        DefaultResponse<ICollection<TEntity>> GetAll();
    }
}