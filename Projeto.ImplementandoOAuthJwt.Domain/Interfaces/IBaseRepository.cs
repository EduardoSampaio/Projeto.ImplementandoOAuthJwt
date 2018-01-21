using System;
using System.Collections.Generic;

namespace Projeto.ImplementandoOAuthJwt.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        IList<TEntity> GetAll(int skip = 0, int take = 50);
    }
}
