using System;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        #region [Properties]

        private readonly IRepositoryBase<TEntity> _repositoryBase;

        #endregion

        #region [Constructor]

        public ServiceBase( IRepositoryBase<TEntity> repositoryBase )
        {
            _repositoryBase = repositoryBase; ;
        }

        #endregion

        #region [Interface]

        
        public void Create( TEntity entity )
        {
            _repositoryBase.Create( entity );
        }

        public void Delete( TEntity entity )
        {
            _repositoryBase.Delete( entity );
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public void Edit( TEntity entity )
        {
            _repositoryBase.Edit( entity );
        }

        #endregion

    }
}
