using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoodenLeg.Application.Interfaces;
using WoodenLeg.Domain.Interfaces.Entities;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Application.Implementation
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class, IEntityBase
    {
        #region [Properties]

        private readonly IServiceBase<TEntity> _appServiceBase;

        #endregion

        #region [Constructor]

        public AppServiceBase( IServiceBase<TEntity> appServiceBase )
        {
            _appServiceBase = appServiceBase;
        }

        #endregion

        #region [Interface]

        public Task<string> Create( TEntity entity )
        {
            return _appServiceBase.Create( entity );
        }

        public Task<bool> Delete( TEntity entity )
        {
            return _appServiceBase.Delete( entity );
        }

        public void Dispose()
        {
            _appServiceBase.Dispose();
        }

        public IEnumerable<TEntity> Get()
        {
            return _appServiceBase.Get();
        }

        public TEntity GetById( string id )
        {
            return _appServiceBase.GetById( id );
        }

        public Task<bool> Update( TEntity entity )
        {
            return _appServiceBase.Update( entity );
        }

        #endregion
    }
}
