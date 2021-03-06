﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoodenLeg.Domain.Interfaces.Entities;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class, IEntityBase
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

        public Task<string> Create( TEntity entity )
        {
            return _repositoryBase.Create( entity );
        }

        public Task<bool> Delete( TEntity entity )
        {
            return _repositoryBase.Delete( entity );
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public IEnumerable<TEntity> Get()
        {
            return _repositoryBase.Get();
        }

        public TEntity GetById( string id )
        {
            return _repositoryBase.GetById( id );
        }

        public Task<bool> Update( TEntity entity )
        {
            return _repositoryBase.Update( entity );
        }


        #endregion

    }
}
