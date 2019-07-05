using System;
using WoodenLeg.Domain.Interfaces.Repositories;

namespace WoodenLeg.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        #region [Interface implementation]
        
        public void Create( TEntity entity )
        {
            throw new NotImplementedException();
        }

        public void Delete( TEntity entity )
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit( TEntity entity )
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
