﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace WoodenLeg.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        #region [Definitions]

        IEnumerable<TEntity> Get();

        TEntity GetById( string id );

        Task<string> Create( TEntity entity );

        Task<bool> Update( TEntity entity );

        Task<bool> Delete( TEntity entity );

        void Dispose();

        #endregion
    }
}
